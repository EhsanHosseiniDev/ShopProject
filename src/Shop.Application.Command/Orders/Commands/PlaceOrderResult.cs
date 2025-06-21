public record PlaceOrderResult(
    Guid OrderId,
    Guid CustomerId,
    DateTime CreatedAt,
    int TotalItems,
    decimal TotalAmount
);
