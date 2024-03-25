using Customers.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Customers.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CustomersController(CustomerService customerService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] UploadImageDto request)
    {
        var guidId = Guid.Parse("3c9ab646-647a-4013-b068-c7250f21c623");
        var response = await customerService.UploadImageAsync(guidId, request.File);
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

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await customerService.DeleteImageAsync(id);
        return response.HttpStatusCode switch
        {
            HttpStatusCode.NoContent => Ok(),
            HttpStatusCode.NotFound => NotFound(),
            _ => BadRequest()
        };
    }
}
