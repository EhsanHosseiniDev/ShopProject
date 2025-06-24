using Shop.Domain.Common;
using System;
using System.Collections.Generic;

namespace Shop.Domain.Aggregators.Orders;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; set; }
    public List<OrderItem> Items { get; private set; }
    public Money TotalAmount { get; private set; }
    public bool IsPaid { get; private set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Order(Guid customerId, IEnumerable<OrderItem> items, Money total)
    {
        CustomerId = customerId;
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
