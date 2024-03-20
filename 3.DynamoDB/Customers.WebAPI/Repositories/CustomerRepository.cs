using Customers.WebAPI.DTOs;

namespace Customers.WebAPI.Repositories;

public sealed class CustomerRepository
{
    public async Task<bool> CreateAsync(CreateCustomerDto customer)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(UpdateCustomerDto customer)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
