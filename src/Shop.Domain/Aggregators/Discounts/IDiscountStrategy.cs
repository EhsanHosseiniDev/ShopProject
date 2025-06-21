using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Products;
using System.Collections.Generic;

namespace Shop.Domain.Aggregators.Discounts;

public interface IDiscountStrategy
{
    Money Apply(Money original, IEnumerable<CartItem> items);
}
