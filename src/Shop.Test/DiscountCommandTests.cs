using Shop.Domain.Common;
using Shop.DomainService.Discounts.DiscountPolicy;

namespace Shop.Test;

public class DiscountCommandTests : IClassFixture<StartupFixture>
{
    [Theory]
    [InlineData(200, 10, 180)]
    [InlineData(1000, 20, 800)]
    public void ShouldApplyValidPercentageDiscount(decimal originalPrice, decimal percent, decimal expected)
    {
        var percentageDiscountPolicy = new PercentageDiscountPolicy(percent);
        var result= percentageDiscountPolicy.Apply(new Money(originalPrice),Guid.NewGuid());

        Assert.Equal(expected, result);
    }
}
