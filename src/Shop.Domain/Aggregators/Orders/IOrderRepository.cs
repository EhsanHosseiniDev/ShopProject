using Shop.Domain.Common;

namespace Shop.Domain.Aggregators.Orders;

public interface IOrderRepository : IRepository<Order>
{
    void UpdateOrder(Order order);
}
