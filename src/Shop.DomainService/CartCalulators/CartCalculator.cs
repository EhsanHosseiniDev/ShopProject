using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Common;
using Shop.DomainService.Discounts.DiscountPolicy;

namespace Shop.DomainService.CartCalulators;

public class CartCalculator : ICartCalculator
{
    private IDiscountPolicy? _discount;

    public CalculateTotalCartResult CalculateTotalCartItems(Cart cart)
    {
        if (cart == null)
            throw new InvalidOperationException("Cart not found");

        var total = cart.Items.Select(i => i.TotalPrice).Aggregate(Money.Zero, (acc, next) => acc + next);
        var effectedAmount = _discount?.Apply(total, cart.CustomerId) ?? total;
        return new CalculateTotalCartResult(_discount?.ToString() ?? string.Empty, total - effectedAmount, effectedAmount);
    }

    public void ApplyDiscount(IDiscountPolicy discountStrategy) => _discount = discountStrategy;
}
