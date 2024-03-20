using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Customers.WebAPI.DTOs;
using Customers.WebAPI.Models;
using System.Net;
using System.Text.Json;

namespace Customers.WebAPI.Repositories;

public sealed class CustomerRepository(
    IAmazonDynamoDB dynamoDb)
{

    private readonly string tableName = "customers";
    public async Task<bool> CreateAsync(CreateCustomerDto request)
    {
        Customer customer = new()
        {
            Address = request.Address,
            Name = request.Name
        };

        var customerAsJson = JsonSerializer.Serialize(customer);
        var customerAsAttributes = Document.FromJson(customerAsJson).ToAttributeMap();

        var createItemRequest = new PutItemRequest
        {
            TableName = tableName,
            Item = customerAsAttributes,
            ConditionExpression = "attribute_not_exists(pk) and attribute_not_exists(sk)"
        };

        var response = await dynamoDb.PutItemAsync(createItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<bool> UpdateAsync(UpdateCustomerDto request)
    {
        Customer customer = new()
        {
            Id = request.Id,
            Address = request.Address,
            Name = request.Name
        };

        var customerAsJson = JsonSerializer.Serialize(customer);
        var customerAsAttributes = Document.FromJson(customerAsJson).ToAttributeMap();

        var updateItemRequest = new PutItemRequest
        {
            TableName = tableName,
            Item = customerAsAttributes           
        };

        var response = await dynamoDb.PutItemAsync(updateItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var deletedItemRequest = new DeleteItemRequest
        {
            TableName = tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "pk", new AttributeValue { S = id.ToString()} },
                { "sk", new AttributeValue { S = id.ToString()} },
            }
        };

        var response = await dynamoDb.DeleteItemAsync(deletedItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var scanRequest = new ScanRequest
        {
            TableName = tableName
        };
        var response = await dynamoDb.ScanAsync(scanRequest);
        return response.Items.Select(s =>
        {
            var json = Document.FromAttributeMap(s).ToJson();
            return JsonSerializer.Deserialize<CustomerDto>(json);
        })!;
    }
}
