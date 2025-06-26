using Microsoft.AspNetCore.Components;
using Shop.Application.Command.Carts.Commands;

namespace Shop.UiLibrary.IntractiveComponents.Components;

public partial class CartView
{
    [Parameter] public CartResult CartResult { get; set; } = new();
    [Parameter] public EventCallback<Guid> OnRemoveClicked { get; set; }
    [Parameter] public EventCallback<(Guid ProductId, int Quantity)> OnQuantityChanged { get; set; }
}