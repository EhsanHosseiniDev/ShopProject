using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Orders;
using Shop.Domain.Aggregators.Products;
using Shop.Domain.Aggregators.Users;
using Shop.DomainService.CartCalulators;
using Shop.DomainService.Discounts.DiscountProvider;
public class AddProductToCartHandler : IRequestHandler<AddProductToCartCommand, AddProductToCartResult>
{
    private readonly IProductRepository _productReposiroey;
    private readonly ICartRepository _cartRepository;
    private readonly ICustomerRepository _customerRepository;

    public AddProductToCartHandler(IProductRepository productService,
        ICartRepository cartRepository,
        ICustomerRepository customerRepository,
        ICartCalculator cartCalculator,
        IDiscountPolicyProvider discountPolicyProvider)
    {
        _productReposiroey = productService;
        _cartRepository = cartRepository;
        _customerRepository = customerRepository;
    }

    public Task<AddProductToCartResult> Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
    {
        var product = _productReposiroey.Find(command.ProductId);
        if (product == null) throw new InvalidOperationException("Product not found");

        var cart = _cartRepository.GetByCustomerId(command.CustomerId)
                   ?? CreateCart(command.CustomerId);

        cart.AddProduct(product.Id, product.Name, product.Price, command.Quantity);
        _cartRepository.UpdateCart(cart);

        return Task.FromResult(new AddProductToCartResult(true, command.CustomerId, product.Id, command.Quantity, cart.Items.Count, cart.CalculateTotal()));
    }

    private Cart CreateCart(Guid customerId)
    {
        var customer = _customerRepository.Find(customerId) ??
            throw new InvalidOperationException("Customer not found");
        var cart = new Cart(customer.Id, customer.Name);
        _cartRepository.Add(cart);
        return cart;
    }
}
