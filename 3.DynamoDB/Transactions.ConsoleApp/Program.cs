using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System.Text.Json;

AmazonDynamoDBClient dynamoDb = new AmazonDynamoDBClient();

ShoppingCart shoppingCart = new()
{
    PK = "1",
    SK = "1",
    ProductName = "Domates"
};

Order order = new()
{
    PK = "1",
    SK = "1",
    ProductName = "Domates"
};

var asJson1 = JsonSerializer.Serialize(shoppingCart);
var asJson2 = JsonSerializer.Serialize(order);

var attributeMap1 = Document.FromJson(asJson1).ToAttributeMap();
var attributeMap2 = Document.FromJson(asJson2).ToAttributeMap();

var transactRequest = new TransactWriteItemsRequest
{
    TransactItems = new List<TransactWriteItem>
    {
        new()
        {
            Put = new()
            {
                TableName = "shopping-carts",
                Item = attributeMap1
            }
        },
        new()
        {
            Put = new()
            {
                TableName = "orders",
                Item = attributeMap2
            }
        }
    }
};

var response = await dynamoDb.TransactWriteItemsAsync(transactRequest);