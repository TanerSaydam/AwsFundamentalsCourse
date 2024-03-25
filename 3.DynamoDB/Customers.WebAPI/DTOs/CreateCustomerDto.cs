namespace Customers.WebAPI.DTOs;

public sealed record CreateCustomerDto(
    string Name,
    string Email);
