public record PlaceOrderResult(
    Guid OrderId,
    Guid CustomerId,
    DateTime CreatedAt,
    int TotalItems,
    string DiscountName,
    decimal DiscountAmount,
    decimal PaybleAmount
);
