using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;

namespace SQSWebAPI.Publisher.Messaging;

public sealed class SendMessage(
    IAmazonSQS sqsClient)
{
    public async Task<SendMessageResponse> SendMessageAsync<T>(T message, CancellationToken cancellationToken = default)
    {
        var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers", cancellationToken);

        var sendMessageRequest = new SendMessageRequest
        {
            QueueUrl = queueUrlResponse.QueueUrl,
            MessageBody = JsonSerializer.Serialize(message),
            MessageAttributes = new Dictionary<string, MessageAttributeValue>
            {
                {
                    "MessageType", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = typeof(T).Name
                    }
                }
            }
        };

        var response = await sqsClient.SendMessageAsync(sendMessageRequest, cancellationToken);

        return response;
    }
}
