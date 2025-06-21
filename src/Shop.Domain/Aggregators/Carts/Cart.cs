using Shop.Domain.Aggregators.Discounts;
using Shop.Domain.Aggregators.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Domain.Aggregators.Carts;

public class Cart(Guid customerId)
{
    private readonly List<CartItem> _items = new();
    private IDiscountStrategy _discount = new NoDiscount();

    public IReadOnlyList<CartItem> Items => _items;

    public Guid CustomerId { get; } = customerId;

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

    public void UpdateQuantity(Guid productId, int newQuantity)
    {
        var item = _items.FirstOrDefault(i => i.Product.Id == productId);
        if (item == null)
            throw new InvalidOperationException("Product not found in cart");

        if (newQuantity <= 0)
        {
            _items.Remove(item);
        }
        else
        {
            item.SetQuantity(newQuantity);
        }
    }

    public void ApplyDiscount(IDiscountStrategy discountStrategy)
    {
        _discount = discountStrategy;
    }

    public Money CalculateTotal()
    {
        var total = _items.Select(i => i.TotalPrice).Aggregate(Money.Zero, (acc, next) => acc + next);
        return _discount.Apply(total, Items);
    }

    public void RemoveProduct(Guid productId)
    {
        var item = _items.FirstOrDefault(i => i.Product.Id == productId);
        if (item == null)
            throw new InvalidOperationException("Product not found in cart");

        _items.Remove(item);
    }
}
