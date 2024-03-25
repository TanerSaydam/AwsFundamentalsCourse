using Customers.WebAPI.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Customers.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly ConnectionStringsOptions _options;

    public ValuesController(IOptionsMonitor<ConnectionStringsOptions> options)
    {
        _options = options.CurrentValue;
    }

    [HttpGet]
    public IActionResult GetConnectionName()
    {
        return Ok(_options.InMemory);
    }
}
