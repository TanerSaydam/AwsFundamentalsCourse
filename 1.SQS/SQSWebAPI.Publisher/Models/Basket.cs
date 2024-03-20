using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace SQSWebAPI.Publisher.Models;

public sealed class Basket
{
    public Basket()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public static List<Basket> GetAll()
    {
        return new()
        {
            new Basket()
            {
                ProductName = "Domates",
                Quantity = 1,
                Price = 10
            },
            new Basket()
            {
                ProductName = "Biber",
                Quantity = 2,
                Price = 20
            },
            new Basket()
            {
                ProductName = "Patlıcan",
                Quantity = 3,
                Price = 30
            },
        };
    }
}
