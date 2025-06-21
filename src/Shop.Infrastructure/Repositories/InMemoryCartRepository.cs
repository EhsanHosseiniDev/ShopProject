using Shop.Domain.Aggregators.Carts;

public class InMemoryCartRepository : ICartRepository
{
    private readonly List<Cart> _carts = new();

    public Task<Cart?> GetByCustomerIdAsync(Guid customerId)
    {
        var cart = _carts.FirstOrDefault(c => c.CustomerId == customerId);
        return Task.FromResult(cart);
    }

    public Task SaveAsync(Cart entity)
    {
        var existing = _carts.FirstOrDefault(c => c.CustomerId == entity.CustomerId);
        if (existing != null)
        {
            _carts.Remove(existing);
        }
        _carts.Add(entity);
        return Task.CompletedTask;
    }
}
