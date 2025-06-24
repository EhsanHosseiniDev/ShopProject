using Shop.Domain.Aggregators.Carts;

public class InMemoryCartRepository : ICartRepository
{
    private readonly List<Cart> _carts = new();

    public void Add(Cart entity)
    {
        var existing = _carts.FirstOrDefault(c => c.CustomerId == entity.CustomerId);
        if (existing != null)
        {
            _carts.Remove(existing);
        }
        _carts.Add(entity);
    }

    public Cart? Find(Guid entityId) => _carts.FirstOrDefault(c => c.Id == entityId);

    public Cart? GetByCustomerId(Guid customId) => _carts.FirstOrDefault(c => c.CustomerId == customId);

    public void UpdateCart(Cart cart)
    {
        var findCart = _carts.Single(c => c.Id == cart.Id);
        findCart = cart;
    }
}
