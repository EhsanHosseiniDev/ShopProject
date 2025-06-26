using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;

public class GetCartQueryHandler(ICartRepository cartRepository) : IRequestHandler<GetCartQuery, CartResult>
{
    public Task<CartResult> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = cartRepository.GetByCustomerId(request.CustomerId);
        if (cart == null)
            return Task.FromResult(new CartResult());

        var cartItemResults = cart.Items.ToCartResults();
        var cartResult = new CartResult()
        {
            Items = cartItemResults,
            PayebleAmount = cart.CalculateTotal()
        };
        return Task.FromResult(cartResult);
    }
}
