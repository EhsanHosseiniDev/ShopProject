namespace Shop.Test;

public class ProductQueryTests
{
    [Theory]
    [InlineData("Mouse", 50)]
    [InlineData("Keyboard", 80)]
    public void Should_return_products_with_valid_data(string name, decimal price)
    {
        
    }
}
