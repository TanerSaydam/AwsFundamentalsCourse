using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

var client = new AmazonSecretsManagerClient();

var listSecretVersionRequest = new ListSecretVersionIdsRequest
{
    SecretId = "apikey",
    IncludeDeprecated = true
};

var versionResponse = await client.ListSecretVersionIdsAsync(listSecretVersionRequest);

var request = new GetSecretValueRequest
{
    SecretId = "apikey",
    //VersionStage = "AWSCURRENT"
    VersionId = "eb259489-391d-4761-823b-c06354f48529"
};
var response = await client.GetSecretValueAsync(request);

Console.WriteLine(response.SecretString);



//var describeSecretRequest = new DescribeSecretRequest
//{
//    SecretId = "apikey"
   
//};

//var describeResponse = await client.DescribeSecretAsync(describeSecretRequest);

//Console.ReadLine();
