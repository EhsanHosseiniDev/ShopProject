using Shop.Domain.Common;
using System;

namespace Shop.Domain.Aggregators.Orders;

public class OrderItem
{
    public Guid ProductId { get; }
    public string ProductName { get; }
    public int Quantity { get; }
    public Money UnitPrice { get; }

    public OrderItem(Guid productId, string productName, int quantity, Money unitPrice)
    {
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public Money TotalPrice => UnitPrice * Quantity;
}
