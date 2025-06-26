using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;

public class UpdateCartItemQuantityHandler(ICartRepository cartRepository) : IRequestHandler<UpdateCartItemQuantityCommand, UpdateCartItemQuantityResult>
{
    public Task<UpdateCartItemQuantityResult> Handle(UpdateCartItemQuantityCommand command, CancellationToken cancellationToken)
    {
        var cart = cartRepository.GetByCustomerId(command.CustomerId)
                   ?? throw new InvalidOperationException("Cart not found");

        cart.UpdateQuantity(command.ProductId, command.NewQuantity);
        cartRepository.UpdateCart(cart);

        return Task.FromResult(new UpdateCartItemQuantityResult(true, command.CustomerId, command.ProductId, command.NewQuantity, cart.CalculateTotal()));
    }
}