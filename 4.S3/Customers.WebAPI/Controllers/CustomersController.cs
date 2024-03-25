using Customers.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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

    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var response = await customerService.GetImageAsync(id);
            return File(response.ResponseStream, response.Headers.ContentType);
        }
        catch (Exception ex) when (ex.Message is "The specified key does not exists")
        {
            return NotFound();
        }
    }
}
