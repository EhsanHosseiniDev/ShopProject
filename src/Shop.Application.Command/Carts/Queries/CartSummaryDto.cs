public record CartSummaryDto(
    Guid CustomerId,
    List<CartItemDto> Items,
    decimal TotalBeforeDiscount,
    decimal DiscountAmount,
    decimal TotalAfterDiscount
);
