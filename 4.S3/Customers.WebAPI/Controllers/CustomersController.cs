using Customers.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomersController(CustomerService customerService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] UploadImageDto request)
    {
        var response = await customerService.UploadImageAsync(Guid.NewGuid(), request.File);
        return Ok(response.HttpStatusCode);
    }
}
