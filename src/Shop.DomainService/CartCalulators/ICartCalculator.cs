using Shop.Domain.Aggregators.Carts;
using Shop.DomainService.Discounts.DiscountPolicy;

namespace Shop.DomainService.CartCalulators;

public interface ICartCalculator
{
    CalculateTotalCartResult CalculateTotalCartItems(Cart cart);
    void ApplyDiscount(IDiscountPolicy discountStrategy);
}