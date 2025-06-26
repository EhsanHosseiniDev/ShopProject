using Shop.Domain.Common;
using System;

namespace Shop.Domain.Aggregators.Carts;

public interface ICartRepository : IRepository<Cart>
{
    Cart? GetByCustomerId(Guid customId);
    void UpdateCart(Cart cart);
    void RemoveCart(Cart cart);
}
