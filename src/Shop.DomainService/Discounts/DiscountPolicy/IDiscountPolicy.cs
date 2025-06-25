using Shop.Domain.Common;

namespace Shop.DomainService.Discounts.DiscountPolicy;

public interface IDiscountPolicy
{
    Money Apply(Money original, Guid customerId);
}
