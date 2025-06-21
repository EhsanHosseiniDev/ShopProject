using Shop.Domain.Aggregators.Products;
using System;

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

    public void SetQuantity(int newQuantity)
    {
        if (newQuantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity must be greater than zero");

        Quantity = newQuantity;
    }

    public Money TotalPrice => Product.Price * Quantity;
}
