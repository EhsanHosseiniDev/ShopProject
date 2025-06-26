using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;

public class RemoveProductFromCartHandler(ICartRepository cartRepository) : IRequestHandler<RemoveProductFromCartCommand, RemoveProductFromCartResult>
{
    public Task<RemoveProductFromCartResult> Handle(RemoveProductFromCartCommand command, CancellationToken cancellationToken)
    {
        var cart = cartRepository.GetByCustomerId(command.CustomerId)
                   ?? throw new InvalidOperationException("Cart not found");

        cart.RemoveProduct(command.ProductId);
        cartRepository.Add(cart);

        return Task.FromResult(new RemoveProductFromCartResult(true, command.CustomerId, command.ProductId, cart.Items.Count, cart.CalculateTotal()));
    }
}
