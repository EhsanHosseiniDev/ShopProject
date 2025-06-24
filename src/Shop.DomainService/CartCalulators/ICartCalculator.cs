using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Common;
using Shop.DomainService.Discounts.DiscountPolicy;

namespace Shop.DomainService.CartCalulators;

public interface ICartCalculator
{
    Money CalculateTotalCartItems(Cart cart);
    void ApplyDiscount(IDiscountPolicy discountStrategy);
}