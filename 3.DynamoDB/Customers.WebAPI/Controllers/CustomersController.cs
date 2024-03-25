using Customers.WebAPI.DTOs;
using Customers.WebAPI.Models;
using Customers.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Customers.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class CustomersController(
    CustomerRepository customerRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerDto request)
    {
        bool result = await customerRepository.CreateAsync(request);

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCustomerDto request)
    {
        DateTime reqestStarted = DateTime.UtcNow;
        bool result = await customerRepository.UpdateAsync(request, reqestStarted);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        bool result = await customerRepository.DeleteByIdAsync(id);

        return NoContent();
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<CustomerDto> customers  = await customerRepository.GetAllAsync();

        return Ok(customers);
    }

    [HttpGet]
    public async Task<IActionResult> GetByEmail(string email)
    {
        Customer? customer = await customerRepository.GetByEmailAsync(email);

        return Ok(customer);
    }
}
