using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

var client = new AmazonSecretsManagerClient();

var request = new GetSecretValueRequest
{
    SecretId = "apikey"
};
var response = await client.GetSecretValueAsync(request);

Console.WriteLine(response.SecretString);

var describeSecretRequest = new DescribeSecretRequest
{
    SecretId = "apikey"
};

var describeResponse = await client.DescribeSecretAsync(describeSecretRequest);

Console.ReadLine();
