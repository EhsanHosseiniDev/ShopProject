using Shop.Domain.Common;

namespace Shop.Domain.Aggregators.Products;

public record Money(decimal Amount, string Currency)
{
    public static Money Zero => new(0, GlobalStatic.EURO);

    public static Money operator +(Money a, Money b) => new(a.Amount + b.Amount, a.Currency);
    public static Money operator *(Money a, int multiplier) => new(a.Amount * multiplier, a.Currency);

    public override string ToString() => $"{Amount:0.00} {Currency}";
}