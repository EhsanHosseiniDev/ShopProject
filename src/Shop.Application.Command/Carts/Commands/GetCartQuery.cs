using MediatR;

namespace Shop.Application.Command.Carts.Commands;

public record GetCartQuery(Guid CustomerId)
    : IRequest<CartResult>;
