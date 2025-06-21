using Shop.Domain.Aggregators.Orders;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Task SaveAsync(Order entity)
    {
        var existing = _orders.FirstOrDefault(o => o.Id == entity.Id);
        if (existing != null)
        {
            _orders.Remove(existing);
        }
        _orders.Add(entity);
        return Task.CompletedTask;
    }
}
