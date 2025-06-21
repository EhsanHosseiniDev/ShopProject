using MediatR;

namespace Shop.Application.Command.Carts.Commands;

public record UpdateCartItemQuantityCommand(Guid CustomerId, Guid ProductId, int NewQuantity)
    : IRequest<UpdateCartItemQuantityResult>;

