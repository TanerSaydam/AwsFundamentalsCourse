using Amazon.SQS;
using Amazon.SQS.Model;
using SQSWebAPI.Consumer.Models;
using System.Text.Json;

namespace SQSWebAPI.Consumer.Messaging;

public sealed class ReceiveMessage
{
    public async Task ReceiveMessageAsync<T>(CancellationToken cancellationToken = default)
    {
        var sqsClient = new AmazonSQSClient();

        var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers", cancellationToken);

        var receiveMessageRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrlResponse.QueueUrl,
            AttributeNames = new List<string> { "All" },
            MessageAttributeNames = new List<string> { "All" }
        };

        while(!cancellationToken.IsCancellationRequested)
        {
            var response = await sqsClient.ReceiveMessageAsync(receiveMessageRequest, cancellationToken);

            foreach (var msg in response.Messages)
            {
                //Mail gönder
                //Sms  gönder
                //DB kaydet

                await Console.Out.WriteLineAsync($"Message Id {msg.MessageId}");
                T? data = JsonSerializer.Deserialize<T>(msg.Body);

                await sqsClient.DeleteMessageAsync(queueUrlResponse.QueueUrl, msg.ReceiptHandle);
            }

            await Task.Delay(100, cancellationToken);
        }
    }
}
