using Shop.Domain.Aggregators.Products;

namespace Shop.Domain.Aggregators.Discounts;

public interface IDiscountStrategy
{
    Money Apply(Money original);
}
