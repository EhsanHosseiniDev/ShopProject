namespace Shop.Test;

public class PaymentCommandTests
{
    [Theory]
    [InlineData(500)]
    [InlineData(999.99)]
    public void Should_mark_payment_as_completed(decimal amount)
    {
        
    }
}
