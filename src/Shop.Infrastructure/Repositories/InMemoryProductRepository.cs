using AutoFixture;
using Shop.Domain.Aggregators.Products;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public InMemoryProductRepository()
    {
        var fixture = new Fixture();
        _products = fixture.Build<Product>()
            .With(p => p.Id, Guid.NewGuid)
            .With(p => p.Name, () => fixture.Create<string>().Substring(0, 8))
            .With(p => p.Price, () => fixture.Create<decimal>() % 100 + 1)
            .With(p => p.Quantity, () => fixture.Create<int>() % 50 + 1)
            .CreateMany(50)
            .ToList();
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
