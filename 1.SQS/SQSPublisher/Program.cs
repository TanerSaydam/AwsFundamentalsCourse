using Amazon.SQS;
using Amazon.SQS.Model;
using System.Net.Http.Headers;
using System.Text.Json;

string accessKey = "";
string secretKey = "";
var region = Amazon.RegionEndpoint.USEast1;

var sqsClient = new AmazonSQSClient(region);

var customer = new
{
    FirstName = "Taner",
    LastName = "Saydam",
    Age = 34
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

var sendMessageRequest = new SendMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        {
            "MessageType", new MessageAttributeValue
            {
                DataType = "String",
                StringValue = "Customer"
            }
        }
    },
    
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);

Console.ReadLine();