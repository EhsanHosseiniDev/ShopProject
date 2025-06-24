using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Orders;

public static class OrderItemExtensions
{
    public static IEnumerable<OrderItem> ToOrderItems(this IEnumerable<CartItem> cartItems)
    {
        return cartItems.Select(item => new OrderItem(item.ProductId, item.ProductName, item.Quantity, item.Price)).ToList();
    }
}