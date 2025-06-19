namespace Shop.Domain.Aggregators.Products;

public class Product
{
    public long ProductId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; } = Money.Zero;
    public int Quantity { get; private set; }

    public Product(long productId, string name, Money price, int quantity)
    {
        ProductId = productId;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void ReduceStock(int quantity) => Quantity += quantity;
}

