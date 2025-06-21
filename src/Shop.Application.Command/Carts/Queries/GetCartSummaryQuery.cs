using MediatR;

public record GetCartSummaryQuery(Guid CustomerId) : IRequest<CartSummaryDto>;
