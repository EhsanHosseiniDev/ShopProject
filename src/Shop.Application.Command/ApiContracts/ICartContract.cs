using Shop.Application.Command.Carts.Commands;

namespace Shop.Application.Command.ApiContracts;

public interface ICartContract
{
    Task<CartSummaryDto> GetCartSummaryQuery(Guid CustomerId);
    Task<AddProductToCartResult> AddProductToCartCommand(Guid CustomerId, Guid ProductId, int Quantity);
    Task<RemoveProductFromCartResult> RemoveProductFromCartCommand(Guid CustomerId, Guid ProductId);
    Task<UpdateCartItemQuantityResult> UpdateCartItemQuantityCommand(Guid CustomerId, Guid ProductId, int NewQuantity);
}
