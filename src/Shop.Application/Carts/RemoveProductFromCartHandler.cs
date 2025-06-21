using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;

public class RemoveProductFromCartHandler : IRequestHandler<RemoveProductFromCartCommand, RemoveProductFromCartResult>
{
    private readonly ICartRepository _cartRepository;

    public RemoveProductFromCartHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<RemoveProductFromCartResult> Handle(RemoveProductFromCartCommand command, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByCustomerIdAsync(command.CustomerId)
                   ?? throw new InvalidOperationException("Cart not found");

        cart.RemoveProduct(command.ProductId);
        await _cartRepository.SaveAsync(cart);

        return new RemoveProductFromCartResult(true, command.CustomerId, command.ProductId, cart.Items.Count, cart.CalculateTotal());
    }
}
