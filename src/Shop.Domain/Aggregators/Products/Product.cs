using System;

namespace Shop.Domain.Aggregators.Products;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; } = Money.Zero;
    public int Quantity { get; private set; }

    public Product(Guid productId, string name, Money price, int quantity)
    {
        Id = productId;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void ReduceStock(int quantity) => Quantity += quantity;
}
