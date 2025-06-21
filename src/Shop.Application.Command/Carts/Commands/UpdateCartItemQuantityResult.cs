namespace Shop.Application.Command.Carts.Commands;

public record UpdateCartItemQuantityResult(
    bool Success,
    Guid CustomerId,
    Guid ProductId,
    int NewQuantity,
    decimal NewCartTotal
);
