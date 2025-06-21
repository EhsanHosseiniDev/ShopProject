using MediatR;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Orders;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, PlaceOrderResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;

    public PlaceOrderHandler(ICartRepository cartRepository, IOrderRepository orderRepository)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
    }

    public async Task<PlaceOrderResult> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByCustomerIdAsync(command.CustomerId)
                   ?? throw new InvalidOperationException("Cart not found");

        if (!cart.Items.Any())
            throw new InvalidOperationException("Cart is empty");

        var order = new Order(cart.CustomerId, cart.Items.ToList(), cart.CalculateTotal());
        await _orderRepository.SaveAsync(order);

        return new PlaceOrderResult(order.Id, order.CustomerId, order.CreatedAt, order.Items.Count, order.TotalAmount);
    }
}