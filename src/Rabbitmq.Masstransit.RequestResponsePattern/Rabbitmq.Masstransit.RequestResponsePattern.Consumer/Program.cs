using MassTransit;
using Rabbitmq.Masstransit.RequestResponsePattern.Consumer.Consumers;
using Rabbitmq.Masstransit.RequestResponsePattern.Shared.RequestResponseMessages;

Console.WriteLine("Consumer");

string rabbitMqUri = "your_rabbitmq_uri";

string requestQueue = "request_queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(rabbitMqUri);
    
    cfg.ReceiveEndpoint(requestQueue, e =>
    {
        e.Consumer<RequestMessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();