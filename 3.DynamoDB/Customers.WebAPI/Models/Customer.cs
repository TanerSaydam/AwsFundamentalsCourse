namespace Customers.WebAPI.Models;

public sealed class Customer
{
    public Customer()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
