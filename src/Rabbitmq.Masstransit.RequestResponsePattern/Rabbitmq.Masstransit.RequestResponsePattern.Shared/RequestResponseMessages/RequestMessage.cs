namespace Rabbitmq.Masstransit.RequestResponsePattern.Shared.RequestResponseMessages;

public record RequestMessage
{
    public int MessageNo { get; set; }
    public string Text { get; set; }
};