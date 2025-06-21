using MediatR;

namespace Shop.Application.Command.Carts.Commands;

public record RemoveProductFromCartCommand(Guid CustomerId, Guid ProductId)
    : IRequest<RemoveProductFromCartResult>;
