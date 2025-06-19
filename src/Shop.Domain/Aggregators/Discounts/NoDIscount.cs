using Shop.Domain.Aggregators.Products;

namespace Shop.Domain.Aggregators.Discounts;

public class NoDIscount : IDiscountStrategy
{
    public Money Apply(Money original) => original;
}
