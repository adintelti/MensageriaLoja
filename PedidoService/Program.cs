using Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

var endpointConfiguration = new EndpointConfiguration("PedidoService");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();
var transport = endpointConfiguration
    .UseTransport<RabbitMQTransport>()
    .UseConventionalRoutingTopology(QueueType.Quorum);

var routing = transport.Routing();
routing.RouteToEndpoint(typeof(CriarPedido), "PedidoService");

var connectionString = "amqp://guest:guest@localhost:5672";
transport.ConnectionString(connectionString);
endpointConfiguration.EnableInstallers();

builder.UseNServiceBus(endpointConfiguration);

var app = builder.Build();

var messageSession = app.Services.GetRequiredService<IMessageSession>();

var pedido = new CriarPedido()
{
    Produto = "Ipad",
    Valor = 200
};

await messageSession.Send(pedido);

app.Run();