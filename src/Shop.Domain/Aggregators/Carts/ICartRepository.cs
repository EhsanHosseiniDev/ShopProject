using Shop.Domain.Common;
using System;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregators.Carts;

public interface ICartRepository: IRepository<Cart>
{
    Task<Cart?> GetByCustomerIdAsync(Guid customerId);
}
