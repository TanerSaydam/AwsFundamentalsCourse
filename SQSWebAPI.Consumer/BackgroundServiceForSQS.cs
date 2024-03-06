
using SQSWebAPI.Consumer.Messaging;
using SQSWebAPI.Consumer.Models;

namespace SQSWebAPI.Consumer;

public sealed class BackgroundServiceForSQS(
    ReceiveMessage receiveMessage) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await receiveMessage.ReceiveMessageAsync<List<Order>>(stoppingToken);
    }
}
