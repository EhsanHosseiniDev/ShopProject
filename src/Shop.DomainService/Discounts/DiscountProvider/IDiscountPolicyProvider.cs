using Shop.DomainService.Discounts.DiscountPolicy;

namespace Shop.DomainService.Discounts.DiscountProvider;

public interface IDiscountPolicyProvider
{
    IDiscountPolicy GetPolicy(string code);
}

