using Shop.Domain.Common;

namespace Shop.DomainService.Discounts.DiscountPolicy;

public class NoDiscount : IDiscountPolicy
{
    public Money Apply(Money original, Guid customerId) => original;
}
