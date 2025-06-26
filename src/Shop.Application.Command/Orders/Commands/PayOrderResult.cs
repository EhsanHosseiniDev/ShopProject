public record PayOrderResult(
    bool Success,
    string? PaymentTrackingCode,
    string? ErrorMessage
);

