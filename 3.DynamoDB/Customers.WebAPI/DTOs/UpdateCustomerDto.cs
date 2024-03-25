namespace Customers.WebAPI.DTOs;

public sealed record UpdateCustomerDto(
    Guid Id,
    string Name,
    string Email);
