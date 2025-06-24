using Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Domain.Aggregators.Carts;

public class Cart(Guid customerId, string customerName)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public List<CartItem> Items { get; private set; } = new();
    public Guid CustomerId { get; private set; } = customerId;
    public string CustomerName { get; private set; } = customerName;

    public void AddProduct(Guid productId, string productname, Money price, int quantity)
    {
        var existing = Items.FirstOrDefault(i => i.ProductId == productId);
        if (existing != null)
        {
            Items.Remove(existing);
            Items.Add(new CartItem(productId, productname, price, existing.Quantity + quantity));
        }
        else
        {
            Items.Add(new CartItem(productId, productname, price, quantity));
        }
    }

    public void UpdateQuantity(Guid productId, int newQuantity)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null)
            throw new InvalidOperationException("Product not found in cart");

        if (newQuantity <= 0)
        {
            Items.Remove(item);
        }
        else
        {
            item.SetQuantity(newQuantity);
        }
    }

    public void RemoveProduct(Guid productId)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null)
            throw new InvalidOperationException("Product not found in cart");

        Items.Remove(item);
    }

    public Money CalculateTotal()
        => Items.Select(i => i.TotalPrice).Aggregate(Money.Zero, (acc, next) => acc + next);
}
