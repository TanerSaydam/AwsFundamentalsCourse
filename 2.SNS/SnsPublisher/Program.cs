using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System.Text.Json;

var message = new
{
    Name= "Taner Saydam",
    Age= 35
};

var snsClient = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.USEast1);

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
                StringValue = "User"
            }
        }
    }
};

var response = await snsClient.PublishAsync(publishRequest);