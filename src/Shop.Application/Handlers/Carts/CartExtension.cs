using Shop.Application.Command.Carts.Commands;
using Shop.Domain.Aggregators.Carts;

public static class CartExtension
{
    public static IEnumerable<CartItemResult> ToCartResults(this IEnumerable<CartItem> cartItems)
    {
        return cartItems.Select(item => new CartItemResult
        {
            ProductId = item.ProductId,
            ProductName = item.ProductName,
            Price = item.Price,
            Quantity = item.Quantity,
            Amount = item.TotalPrice,
        });
    }
}
