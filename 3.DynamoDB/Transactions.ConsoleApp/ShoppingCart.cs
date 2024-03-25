using System.Text.Json.Serialization;

public sealed class ShoppingCart
{
    [JsonPropertyName("pk")]
    public string PK { get; set; } = string.Empty;
    [JsonPropertyName("sk")]
    public string SK { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
}

