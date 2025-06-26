using MediatR;
using Shop.Domain.Aggregators.Orders;

public class PayOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<PayOrderCommand, PayOrderResult>
{
    public Task<PayOrderResult> Handle(PayOrderCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.PaymentMethod))
            return Task.FromResult(new PayOrderResult(false, null, "Payment method is required."));

        var order = orderRepository.Find(command.OrderId) ?? throw new InvalidOperationException("Order not fount");

        var trackingCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        order.MarkAsPaid(trackingCode, command.PaymentMethod);
        orderRepository.UpdateOrder(order);
        return Task.FromResult(new PayOrderResult(true, trackingCode, null));
    }
}
