using Shop.Domain.Aggregators.Products;

namespace Shop.Domain.Aggregators.Payments;

public class Payment
{
    public long Id { get; private set; }
    public long OrderId { get; private set; }
    public Money Amount { get; private set; }
    public PaymentStatus Status { get; private set; }

    private Payment(long orderId, Money amount)
    {
        OrderId = orderId;
        Amount = amount;
        Status = PaymentStatus.Pending;
    }

    public void Complete() => Status = PaymentStatus.Completed;
    public void Fail() => Status = PaymentStatus.Failed;

    public static Payment Create(long orderId, Money amount)
        => new(orderId, amount);
}
