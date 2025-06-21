using AutoFixture;
using Shop.Domain.Aggregators.Products;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public InMemoryProductRepository()
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

        _products = products;
    }

    public Task<PagedResult<Product>> GetPagedAsync(int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;
        var items = _products.Skip(skip).Take(pageSize).ToList();
        return Task.FromResult(new PagedResult<Product>(items, _products.Count, page, pageSize));
    }

    public Task<Product> GetByIdAsync(Guid productId)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        return Task.FromResult(product);
    }

    public Task SaveAsync(Product entity)
    {
        var existing = _products.FirstOrDefault(p => p.Id == entity.Id);
        if (existing != null)
        {
            _products.Remove(existing);
        }
        _products.Add(entity);
        return Task.CompletedTask;
    }
}
