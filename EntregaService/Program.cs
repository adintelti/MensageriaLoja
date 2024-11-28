using Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

var endpointConfiguration = new EndpointConfiguration("EntregaService");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();
var transport = endpointConfiguration
    .UseTransport<RabbitMQTransport>()
    .UseConventionalRoutingTopology(QueueType.Quorum);

var connectionString = "amqp://guest:guest@localhost:5672";
transport.ConnectionString(connectionString);

var persistence = endpointConfiguration.UsePersistence<LearningPersistence>();
endpointConfiguration.EnableInstallers();

builder.UseNServiceBus(endpointConfiguration);

var app = builder.Build();

var messageSession = app.Services.GetRequiredService<IMessageSession>();

app.Run();