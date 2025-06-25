using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;
using Shop.DomainService.CartCalulators;
using Shop.DomainService.Discounts.DiscountProvider;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartCalculator _cartCalculator;
    private readonly IDiscountPolicyProvider _discountPolicyProvider;

    public GetCartQueryHandler(ICartRepository cartRepository,
        ICartCalculator cartCalculator,
        IDiscountPolicyProvider discountPolicyProvider)
    {
        _cartRepository = cartRepository;
        _cartCalculator = cartCalculator;
        _discountPolicyProvider = discountPolicyProvider;
    }

    public Task<CartResult> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = _cartRepository.GetByCustomerId(request.CustomerId)
                   ?? throw new InvalidOperationException("Product not found");

        var discountPolicy = _discountPolicyProvider.GetPolicy(request.discountCode);
        _cartCalculator.ApplyDiscount(discountPolicy);
        var calculate = _cartCalculator.CalculateTotalCartItems(cart);

        var cartItemResults = cart.Items.ToCartResults();
        var cartResult = new CartResult()
        {
            Items = cartItemResults,
            DiscountName = calculate.DiscountName,
            DiscountAmount = calculate.DiscountAmount,
            PayebleAmount = calculate.EffectedDiscountAmount
        };
        return Task.FromResult(cartResult);
    }
}
