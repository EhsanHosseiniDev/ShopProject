using AutoFixture;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Products;
using Shop.Domain.Aggregators.Users;
using Shop.Domain.Common;

namespace Shop.Test;

public class CartQueryTests : IClassFixture<StartupFixture>
{
    [Theory]
    [InlineData(50, 2, 80, 3, 340)]
    [InlineData(20, 5, 100, 1, 200)]
    [InlineData(10, 10, 15, 2, 130)]
    public void ShouldReturnSummaryWithAllItemsAndPrices(decimal price1, int quantity1, decimal price2, int quantity2, decimal expectedTotal)
    {
        var fixture=new Fixture();
        var customer = fixture.Create<Customer>();
        var cart = new Cart(customer.Id, customer.Name);

        var product1 = new Product(Guid.NewGuid(), "Item1", new Money(price1), 100);
        var product2 = new Product(Guid.NewGuid(), "Item2", new Money(price2), 100);

        cart.AddProduct(product1.Id, product1.Name, product1.Price, quantity1);
        cart.AddProduct(product2.Id, product2.Name, product2.Price, quantity2);

        var total = cart.CalculateTotal();

        Assert.Equal(new Money(expectedTotal), total);
    }
}
