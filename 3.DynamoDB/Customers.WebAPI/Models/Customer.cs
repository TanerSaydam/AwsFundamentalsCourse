using System.Text.Json.Serialization;

namespace Customers.WebAPI.Models;

public sealed class Customer
{
    public Customer()
    {
        Id = Guid.NewGuid();
    }

    [JsonPropertyName("pk")]
    public string Pk => Id.ToString();

    [JsonPropertyName("sk")]
    public string Sk => Id.ToString();
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? UpdatedAt { get; set; }
}
