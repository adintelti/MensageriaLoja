using Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

var endpointConfiguration = new EndpointConfiguration("PagamentoService");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();
var transport = endpointConfiguration
    .UseTransport<RabbitMQTransport>()
    .UseConventionalRoutingTopology(QueueType.Quorum);

var connectionString = "amqp://guest:guest@localhost:5672";
transport.ConnectionString(connectionString);
endpointConfiguration.EnableInstallers();

builder.UseNServiceBus(endpointConfiguration);

var app = builder.Build();

var messageSession = app.Services.GetRequiredService<IMessageSession>();

//var pedidoCriado = new PedidoCriado()
//{
//    Produto = "Ipad",
//};

//await messageSession.Publish(pedidoCriado);

app.Run();