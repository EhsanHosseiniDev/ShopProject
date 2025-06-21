using MediatR;

public record PlaceOrderCommand(Guid CustomerId)
    : IRequest<PlaceOrderResult>;
