using MediatR;

public record PlaceOrderCommand(Guid CustomerId, string discountCode)
    : IRequest<PlaceOrderResult>;

