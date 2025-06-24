namespace Shop.Domain.Common;

public record Money
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public Money(decimal amount)
    {
        Amount = amount;
        Currency = GlobalStatic.EURO;
    }

    public static Money Zero => new(0, GlobalStatic.EURO);

    public static Money operator +(Money a, Money b) => new(a.Amount + b.Amount, a.Currency);
    public static Money operator *(Money money, int multiplier) => new(money.Amount * multiplier, money.Currency);
    public static Money operator *(Money money, decimal multiplier) => new(money.Amount * multiplier, money.Currency);

    public override string ToString() => $"{Amount:0.00} {Currency}";
    public static implicit operator decimal(Money money) => money.Amount;
}