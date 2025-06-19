namespace Shop.Test;

public class DiscountCommandTests
{
    [Theory]
    [InlineData(200, 10, 180)]
    [InlineData(1000, 20, 800)]
    public void Should_apply_valid_percentage_discount(decimal originalPrice, decimal percent, decimal expected)
    {
        
    }

    [Theory]
    [InlineData(500)]
    [InlineData(1000)]
    public void Should_fallback_to_no_discount_for_invalid_code(decimal originalPrice)
    {
        
    }
}
