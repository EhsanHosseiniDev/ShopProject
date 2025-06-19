using Shop.Domain.Aggregators.Products;

namespace Shop.Domain.Aggregators.Carts;

public class CartItem
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public Money TotalPrice => Product.Price * Quantity;
}
