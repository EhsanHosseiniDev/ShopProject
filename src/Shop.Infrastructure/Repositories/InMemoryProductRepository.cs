using AutoFixture;
using Shop.Domain.Aggregators.Products;
using Shop.Domain.Common;

public class InMemoryProductRepository : IProductRepository
{
    private List<Product>? _products;
    private List<Product> Products => _products ??= GenerateRandomProducts();

    public PagedResult<Product> GetPaged(int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;
        var items = Products.Skip(skip).Take(pageSize).ToList();
        return new PagedResult<Product>(items, Products.Count, page, pageSize);
    }

    public Product? Find(Guid entityId) => Products.FirstOrDefault(p => p.Id == entityId);

    public void Add(Product entity)
    {
        var existing = Products.FirstOrDefault(p => p.Id == entity.Id);
        if (existing != null)
        {
            Products.Remove(existing);
        }
        Products.Add(entity);
    }

    private List<Product> GenerateRandomProducts()
    {
        var baseNames = new[]
                {
            "Wireless Mouse", "Gaming Keyboard", "Bluetooth Speaker",
            "USB-C Charger", "HDMI Cable", "Webcam", "Laptop Stand",
            "External SSD", "Noise-Canceling Headphones", "Smartphone Holder"
        };

        var fixture = new Fixture();
        var products = new List<Product>();

        for (int i = 0; i < 50; i++)
        {
            var nameIndex = i % baseNames.Length;
            var uniqueName = $"{baseNames[nameIndex]} #{i + 1}";

            products.Add(new Product(
                Guid.NewGuid(),
                uniqueName,
                new Money(10 + i % 30),
                5 + i % 20
            ));
        }

        return products;
    }
}
