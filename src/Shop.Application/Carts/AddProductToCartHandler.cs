using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Products;

public class AddProductToCartHandler : IRequestHandler<AddProductToCartCommand, AddProductToCartResult>
{
    private readonly IProductRepository _productReposiroey;
    private readonly ICartRepository _cartRepository;

    public AddProductToCartHandler(IProductRepository productService, ICartRepository cartRepository)
    {
        _productReposiroey = productService;
        _cartRepository = cartRepository;
    }

    public async Task<AddProductToCartResult> Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
    {
        var product = await _productReposiroey.GetByIdAsync(command.ProductId);
        if (product == null) throw new InvalidOperationException("Product not found");

        var cart = await _cartRepository.GetByCustomerIdAsync(command.CustomerId)
                   ?? new Cart(command.CustomerId);

        cart.AddProduct(product, command.Quantity);
        await _cartRepository.SaveAsync(cart);

        return new AddProductToCartResult(true, command.CustomerId, product.Id, command.Quantity, cart.Items.Count, cart.CalculateTotal());
    }
}
