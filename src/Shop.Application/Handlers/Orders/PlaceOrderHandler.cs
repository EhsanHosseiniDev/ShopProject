using MediatR;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Orders;
using Shop.DomainService.CartCalulators;
using Shop.DomainService.Discounts.DiscountProvider;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, PlaceOrderResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ICartCalculator _cartCalculator;
    private readonly IDiscountPolicyProvider _discountPolicyProvider;

    public PlaceOrderHandler(ICartRepository cartRepository, 
        IOrderRepository orderRepository,
        ICartCalculator cartCalculator,
        IDiscountPolicyProvider discountPolicyProvider)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
        _cartCalculator = cartCalculator;
        _discountPolicyProvider = discountPolicyProvider;
    }

    public Task<PlaceOrderResult> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
    {
        var cart = _cartRepository.GetByCustomerId(command.CustomerId)
                   ?? throw new InvalidOperationException("Cart not found");

        if (!cart.Items.Any())
            throw new InvalidOperationException("Cart is empty");

        var discountPolicy=_discountPolicyProvider.GetPolicy(command.discountCode);
        _cartCalculator.ApplyDiscount(discountPolicy);

        var order = new Order(cart.CustomerId, cart.Items.ToOrderItems(),_cartCalculator.CalculateTotalCartItems(cart));
        _orderRepository.Add(order);

        return Task.FromResult(new PlaceOrderResult(order.Id, order.CustomerId, order.CreatedAt, order.Items.Count, order.TotalAmount));
    }
}
