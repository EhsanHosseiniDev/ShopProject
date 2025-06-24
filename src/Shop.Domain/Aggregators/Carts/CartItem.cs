using Shop.Domain.Common;
using System;

namespace Shop.Domain.Aggregators.Carts;

public class CartItem
{
    public Guid ProductId { get; }
    public string ProductName { get; private set; }
    public Money Price { get; private set; }
    public int Quantity { get; private set; }

    public CartItem(Guid productId, string productName, Money price, int quantity)
    {
        ProductId = productId;
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }

    public void SetQuantity(int newQuantity)
    {
        if (newQuantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity must be greater than zero");

        Quantity = newQuantity;
    }

    public void IncreaseQuantity(int quantity) => Quantity += quantity;

    public Money TotalPrice => Price * Quantity;
}
