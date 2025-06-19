namespace Shop.Test;

public class CartCommandTests
{
    [Theory]
    [InlineData("Mouse", 50, 2)]
    [InlineData("Keyboard", 80, 3)]
    public void Should_add_product_to_empty_cart(string name, decimal price, int quantity)
    {
        
    }

    [Fact]
    public void Should_accumulate_quantity_if_product_already_in_cart()
    {
        
    }
}
