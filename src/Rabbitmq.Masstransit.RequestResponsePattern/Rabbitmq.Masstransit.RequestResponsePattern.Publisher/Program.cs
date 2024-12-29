using MassTransit;
using Rabbitmq.Masstransit.RequestResponsePattern.Shared.RequestResponseMessages;

Console.WriteLine("Publisher");

string rabbitMqUri = "your_rabbitmq_uri";

string requestQueue = "request_queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(rabbitMqUri);
});

await bus.StartAsync();

var request = bus.CreateRequestClient<RequestMessage>(new Uri($"{rabbitMqUri}/{requestQueue}"));

int i = 1;
while (true)
{
    
    await Task.Delay(200);
    var response = await request.GetResponse<ResponseMessage>(new()
    {
        MessageNo = i, 
        Text = $"{i++}. request"
    });
    Console.WriteLine($"Response Received: {response.Message.Text}");
}
