using AutoFixture;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Orders;
using Shop.Domain.Aggregators.Products;
using Shop.Domain.Aggregators.Users;
using Shop.Domain.Common;
using Shop.DomainService.Discounts.DiscountPolicy;
using Shop.DomainService.Discounts.DiscountProvider;

namespace Shop.Test;

public class OrderCommandTests : IClassFixture<StartupFixture>
{
    private readonly IMediator _mediator;
    private readonly IOrderRepository _orderRepository;

    public OrderCommandTests(StartupFixture startupFixture)
    {
        _mediator = startupFixture.ServiceProvider.GetRequiredService<IMediator>();
        _orderRepository = startupFixture.ServiceProvider.GetRequiredService<IOrderRepository>();
    }

    [Theory]
    [InlineData(300, 2, 600)]
    [InlineData(150, 3, 450)]
    public async Task ShouldCreateOrderFromCart(decimal price, int quantity, decimal expectedTotal)
    {
        var customer = new Customer();
        var productId = Guid.NewGuid();
        var product = new Product(productId, "TestProduct", new Money(price), 100);

        var cart = new Cart(customer.Id, customer.Name);
        cart.AddProduct(product.Id, product.Name, product.Price, quantity);

        var discountServiceMock = new Mock<IDiscountPolicyProvider>();
        discountServiceMock
            .Setup(x => x.GetPolicy(It.IsAny<string>()))
            .Returns(new NoDiscount());
        var command = new PlaceOrderCommand(customer.Id, string.Empty);
        var orderResult = await _mediator.Send(command);

        var order = _orderRepository.Find(orderResult.OrderId);

        Assert.Equal(customer.Id, order?.CustomerId);
        Assert.Equal(productId, order?.Items[0].ProductId);
        Assert.Equal(quantity, order?.Items[0].Quantity);
        Assert.Equal(new Money(expectedTotal), order?.TotalAmount);
    }
}
