using Shop.Domain.Common;

namespace Shop.DomainService.Discounts.DiscountPolicy;

public class PercentageDiscountPolicy : IDiscountPolicy
{
    private readonly decimal _percent;
    public PercentageDiscountPolicy(decimal percent) => _percent = percent;

    public Money Apply(Money originalPrice, Guid customerId)
        => originalPrice * (1 - _percent / 100);
}
