using Shop.Application.Command.Carts.Commands;

namespace BlazorApp.Components.Pages;

public partial class CartPage
{
    private CartResult CartResult = new();
    private Guid CustomerId = Guid.NewGuid();

    protected override async Task OnInitializedAsync() => await LoadCartAsync();

    private async Task LoadCartAsync()
    {
        var command = new GetCartQuery(CustomerId);
        CartResult = await Mediator.Send(command);
    }

    private async Task OnRemoveClicked(Guid productId)
    {
        var result = await Mediator.Send(new RemoveProductFromCartCommand(CustomerId, productId));
        if (result.Success)
            await LoadCartAsync();
    }

    private async Task ChangeQuantity((Guid ProductId, int Quantity) data)
    {
        var result = await Mediator.Send(new UpdateCartItemQuantityCommand(CustomerId, data.ProductId, data.Quantity));
        if (result.Success)
            await LoadCartAsync();
    }

    private void SubmitInvoice() => Navigation.NavigateTo("/place-order");
}