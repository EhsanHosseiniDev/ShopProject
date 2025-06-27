using AutoFixture;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Orders;
using Shop.Domain.Aggregators.Products;
using Shop.Domain.Aggregators.Users;
using Shop.Domain.Common;
using Shop.DomainService.CartCalulators;
using Shop.DomainService.Discounts.DiscountPolicy;
using Shop.DomainService.Discounts.DiscountProvider;

namespace Shop.Test;

public class OrderCommandTests : IClassFixture<StartupFixture>
{
    private readonly ICartCalculator _cartCalculator;

    public OrderCommandTests(StartupFixture startupFixture)
    {
        _cartCalculator = startupFixture.ServiceProvider.GetRequiredService<ICartCalculator>();
    }

    [Theory]
    [InlineData(300, 2, 600)]
    [InlineData(150, 3, 450)]
    public async Task ShouldCreateOrderFromCart(decimal price, int quantity, decimal expectedTotal)
    {
        var customer = new Customer()
        {
            Id = Guid.NewGuid(),
        };
        var productId = Guid.NewGuid();
        var product = new Product(productId, "TestProduct", new Money(price), 100);
        Order? capturedOrder = null;

        var cart = new Cart(customer.Id, customer.Name);
        cart.AddProduct(product.Id, product.Name, product.Price, quantity);

        var cartRepositoryMock = new Mock<ICartRepository>();
        cartRepositoryMock.Setup(x => x.GetByCustomerId(It.IsAny<Guid>())).Returns(cart);

        var orderRepositoryMock = new Mock<IOrderRepository>();
        orderRepositoryMock.Setup(x => x.Add(It.IsAny<Order>())).Callback<Order>(order => capturedOrder = order);

        var discountServiceMock = new Mock<IDiscountPolicyProvider>();
        discountServiceMock
            .Setup(x => x.GetPolicy(It.IsAny<string>()))
            .Returns(new NoDiscount());
        var command = new PlaceOrderCommand(customer.Id, string.Empty);

        var handler = new PlaceOrderHandler(cartRepositoryMock.Object,
            orderRepositoryMock.Object,
            _cartCalculator,
            discountServiceMock.Object);

        var orderResult = await handler.Handle(command, default);

        Assert.Equal(customer.Id, capturedOrder?.CustomerId);
        Assert.Equal(productId, capturedOrder?.Items[0].ProductId);
        Assert.Equal(quantity, capturedOrder?.Items[0].Quantity);
        Assert.Equal(new Money(expectedTotal), capturedOrder?.TotalAmount);
    }
}
