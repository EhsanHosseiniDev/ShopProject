using MediatR;
using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Products;
using Shop.Domain.Aggregators.Users;

public class AddProductToCartHandler(IProductRepository productService,
    ICartRepository cartRepository,
    ICustomerRepository customerRepository) : IRequestHandler<AddProductToCartCommand, AddProductToCartResult>
{
    public Task<AddProductToCartResult> Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
    {
        var product = productService.Find(command.ProductId);
        if (product == null) throw new InvalidOperationException("Product not found");

        var cart = cartRepository.GetByCustomerId(command.CustomerId)
                   ?? CreateCart(command.CustomerId);

        cart.AddProduct(product.Id, product.Name, product.Price, command.Quantity);
        cartRepository.UpdateCart(cart);

        return Task.FromResult(new AddProductToCartResult(true, command.CustomerId, product.Id, command.Quantity, cart.Items.Count, cart.CalculateTotal()));
    }

    private Cart CreateCart(Guid customerId)
    {
        var customer = customerRepository.Find(customerId) ??
            throw new InvalidOperationException("Customer not found");
        var cart = new Cart(customer.Id, customer.Name);
        cartRepository.Add(cart);
        return cart;
    }
}
