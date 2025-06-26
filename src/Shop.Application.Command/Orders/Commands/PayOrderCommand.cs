using MediatR;

public record PayOrderCommand(Guid OrderId, string PaymentMethod) : IRequest<PayOrderResult>;

