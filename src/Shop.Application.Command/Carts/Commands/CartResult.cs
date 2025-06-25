namespace Shop.Application.Command.Carts.Commands;

public record CartResult
{
    public IEnumerable<CartItemResult> Items { get; set; } = [];
    public string DiscountName { get; set; } = string.Empty;
    public decimal DiscountAmount { get; set; }
    public decimal PayebleAmount { get; set; }
}
