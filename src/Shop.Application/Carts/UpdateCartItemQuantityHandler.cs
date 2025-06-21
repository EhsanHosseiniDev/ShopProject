using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;

public class UpdateCartItemQuantityHandler : IRequestHandler<UpdateCartItemQuantityCommand, UpdateCartItemQuantityResult>
{
    private readonly ICartRepository _cartRepository;

    public UpdateCartItemQuantityHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<UpdateCartItemQuantityResult> Handle(UpdateCartItemQuantityCommand command, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByCustomerIdAsync(command.CustomerId)
                   ?? throw new InvalidOperationException("Cart not found");

        cart.UpdateQuantity(command.ProductId, command.NewQuantity);
        await _cartRepository.SaveAsync(cart);

        return new UpdateCartItemQuantityResult(true, command.CustomerId, command.ProductId, command.NewQuantity, cart.CalculateTotal());
    }
}