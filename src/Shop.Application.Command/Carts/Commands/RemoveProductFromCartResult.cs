namespace Shop.Application.Command.Carts.Commands;

public record RemoveProductFromCartResult(
    bool Success,
    Guid CustomerId,
    Guid ProductId,
    int TotalItemsRemaining,
    decimal NewCartTotal
);