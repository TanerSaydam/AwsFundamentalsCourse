using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQSWebAPI.Publisher.Messaging;
using SQSWebAPI.Publisher.Models;
using System.Text;

namespace SQSWebAPI.Publisher.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class BasketsController(
    SendMessage sqs) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CreateOrder()
    {
        List<Basket> baskets = Basket.GetAll();
        List<Order> orders = new List<Order>();

        foreach (var basket in baskets)
        {
            Order order = new()
            {
                Price = basket.Price,
                ProductName = basket.ProductName,
                Quantity = basket.Quantity,
            };

            orders.Add(order);
            //string value = order.Quantity == 1 ? "true" : "false";
            await sqs.SendMessageAsync(order, "false");
        }

        //DB İşlemleri

        //Mail Gönderme
        

        return Ok(new { Message = "Sipariş başarıyla oluşturuldu" });
    }
}
