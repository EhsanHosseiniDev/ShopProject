public record CartItemDto(
    Guid ProductId,
    string Name,
    decimal Price,
    int Quantity,
    decimal Total
);
