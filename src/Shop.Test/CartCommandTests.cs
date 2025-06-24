using AutoFixture;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Products;
using Shop.Domain.Aggregators.Users;
using Shop.Domain.Common;

namespace Shop.Test;

public class CartCommandTests
{
    [Theory]
    [InlineData("Mouse", 50, 2)]
    [InlineData("Keyboard", 80, 3)]
    public void ShouldAddProductToEmptyCart(string name, decimal price, int quantity)
    {
        var productId = Guid.NewGuid();
        var customer = CreateCustomer();
        var cart = new Cart(customer.Id, customer.Name);
        var product = new Product(productId, name, new Money(price), 100);

        cart.AddProduct(product.Id, product.Name, product.Price, quantity);

        Assert.Single(cart.Items);
        var item = cart.Items.First();
        Assert.Equal(productId, item.ProductId);
        Assert.Equal(quantity, item.Quantity);
    }

    [Fact]
    public void ShouldAccumulateQuantityIfProductAlreadyInCart()
    {
        var productId = Guid.NewGuid();
        var customer = CreateCustomer();
        var cart = new Cart(customer.Id, customer.Name);
        var product = new Product(productId, "Monitor", new Money(250), 100);

        cart.AddProduct(product.Id, product.Name, product.Price, 2);
        cart.AddProduct(product.Id, product.Name, product.Price, 3);

        Assert.Single(cart.Items);
        var item = cart.Items.First();
        Assert.Equal(productId, item.ProductId);
        Assert.Equal(5, item.Quantity);
    }

    private static Customer CreateCustomer()
    {
        var fixture = new Fixture();
        var customer = fixture.Create<Customer>();
        return customer;
    }
}
