using MediatR;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Orders;
using Shop.DomainService.CartCalulators;
using Shop.DomainService.Discounts.DiscountProvider;

public class PlaceOrderHandler(ICartRepository cartRepository,
    IOrderRepository orderRepository,
    ICartCalculator cartCalculator,
    IDiscountPolicyProvider discountPolicyProvider) : IRequestHandler<PlaceOrderCommand, PlaceOrderResult>
{
    public Task<PlaceOrderResult> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
    {
        var cart = cartRepository.GetByCustomerId(command.CustomerId)
                   ?? throw new InvalidOperationException("Cart not found");

        if (!cart.Items.Any())
            throw new InvalidOperationException("Cart is empty");

        var discountPolicy = discountPolicyProvider.GetPolicy(command.discountCode);
        cartCalculator.ApplyDiscount(discountPolicy);
        var calculate = cartCalculator.CalculateTotalCartItems(cart);

        var order = new Order(cart.CustomerId, cart.Items.ToOrderItems(), calculate.DiscountAmount, calculate.EffectedDiscountAmount);
        orderRepository.Add(order);
        cartRepository.RemoveCart(cart);
        var placeOrderResult = new PlaceOrderResult(order.Id,
            order.CustomerId,
            order.CreatedAt,
            order.Items.Count,
            calculate.DiscountName,
            calculate.DiscountAmount,
            calculate.EffectedDiscountAmount);

        return Task.FromResult(placeOrderResult);
    }
}
