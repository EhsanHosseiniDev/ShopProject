using Shop.Domain.Common;

namespace Shop.DomainService.Discounts.DiscountPolicy;

public class FixedDiscountPolicy : IDiscountPolicy
{
    private readonly decimal _amount;
    public FixedDiscountPolicy(decimal amount) => _amount = amount;

    public Money Apply(Money originalPrice, Guid customerId)
        => new Money(originalPrice.Amount - _amount);
}
