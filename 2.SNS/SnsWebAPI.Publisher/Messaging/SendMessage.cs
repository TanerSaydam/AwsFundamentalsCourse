using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System.Text.Json;

namespace SQSWebAPI.Publisher.Messaging;

public sealed class SendMessage(
    IAmazonSimpleNotificationService snsClient)
{
    public async Task<PublishResponse> SendMessageAsync<T>(T message, string value, CancellationToken cancellationToken = default)
    {
        var topicArnResponse = await snsClient.FindTopicAsync("customers");

        var publishRequest = new PublishRequest
        {
            TopicArn = topicArnResponse.TopicArn,
            Message = JsonSerializer.Serialize(message),
            MessageAttributes = new Dictionary<string, MessageAttributeValue>
            {
                {
                    "MessageType", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = value
                    }
                }
            }
        };

        var response = await snsClient.PublishAsync(publishRequest);

        return response;
    }
}
