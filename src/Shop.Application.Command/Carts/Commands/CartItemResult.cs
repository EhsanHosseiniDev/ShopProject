namespace Shop.Application.Command.Carts.Commands;

public record CartItemResult
{
    public Guid ProductId { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public decimal Amount { get; init; }
}
