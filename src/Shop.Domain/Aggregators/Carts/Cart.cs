using Shop.Domain.Aggregators.Discounts;
using Shop.Domain.Aggregators.Products;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Domain.Aggregators.Carts;

public class Cart
{
    private readonly List<CartItem> _items = new();
    private IDiscountStrategy _discount = new NoDIscount();

    public IReadOnlyList<CartItem> Items => _items;

    public void AddProduct(Product product, int quantity)
    {
        var existing = _items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existing != null)
        {
            _items.Remove(existing);
            _items.Add(new CartItem(product, existing.Quantity + quantity));
        }
        else
        {
            _items.Add(new CartItem(product, quantity));
        }
    }

    public void ApplyDiscount(IDiscountStrategy discountStrategy)
    {
        _discount = discountStrategy;
    }

    public Money CalculateTotal()
    {
        var total = _items.Select(i => i.TotalPrice).Aggregate(Money.Zero, (acc, next) => acc + next);
        return _discount.Apply(total);
    }
}
