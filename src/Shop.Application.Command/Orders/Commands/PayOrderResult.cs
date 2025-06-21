public record PayOrderResult(
    bool Success,
    string? PaymentId,
    DateTime PaidAt,
    Guid OrderId,
    decimal Amount
);

