using Amazon.SQS;
using Amazon.SQS.Model;

var queueName = args.Length == 1 ? args[0] : "customers";

var sqsClient = new AmazonSQSClient();

var queueUrlResponse = await sqsClient.GetQueueUrlAsync(queueName);

var receiveMessageRequest = new ReceiveMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    AttributeNames = new List<string>() { "All" },
    MessageAttributeNames = new List<string>() { "All" }
};

var cts = new CancellationTokenSource();

while (!cts.IsCancellationRequested)
{
    var response = await sqsClient.ReceiveMessageAsync(receiveMessageRequest);

    foreach (var message in response.Messages)
    {      
        try
        {
            Console.WriteLine($"Message Id: {message.MessageId}");
            Console.WriteLine($"Message Body: {message.Body}");

            await sqsClient.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle);

        }
        catch (Exception ex)
        {

        }

    }

    await Task.Delay(100, cts.Token);
}