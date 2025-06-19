using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Products;
using System;
using System.Collections.Generic;

namespace Shop.Domain.Aggregators.Orders;

public class Order
{
    public long Id { get; private set; }
    public List<CartItem> Items { get; private set; }
    public Money TotalAmount { get; private set; }
    public bool IsPaid { get; private set; }

    public Order(IEnumerable<CartItem> items, Money total)
    {
        Items = new(items);
        TotalAmount = total;
        IsPaid = false;
    }

    public void MarkAsPaid()
    {
        if (IsPaid)
            throw new InvalidOperationException("Order already paid");
        IsPaid = true;
    }
}
