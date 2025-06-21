namespace Shop.Application.Command.Carts.Commands;

public record AddProductToCartResult(
    bool Success,
    Guid CustomerId,
    Guid ProductId,
    int Quantity,
    int TotalItemsInCart,
    decimal CartTotal
);
