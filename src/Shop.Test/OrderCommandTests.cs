namespace Shop.Test;

public class OrderCommandTests
{
    [Theory]
    [InlineData(300, 2, 600)]
    [InlineData(150, 3, 450)]
    public void Should_create_order_from_cart(decimal price, int quantity, decimal expectedTotal)
    {
        
    }
}
