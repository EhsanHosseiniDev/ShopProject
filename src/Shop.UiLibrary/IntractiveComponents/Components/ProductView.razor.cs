using Microsoft.AspNetCore.Components;
using Shop.Application.Command.Carts.Commands;

namespace Shop.UiLibrary.IntractiveComponents.Components;

public partial class ProductView
{
    [Parameter] public Func<int, int, Task<PagedProductDtoResult>>? OnLoadPage { get; set; }
    [Parameter] public Func<Guid, Task<AddProductToCartResult>>? OnAddToCart { get; set; }

    [Parameter] public RenderFragment<ProductDto>? ItemTemplate { get; set; }
    [Parameter] public RenderFragment<(int currentPage, int totalPages)>? PaginationTemplate { get; set; }
    [Parameter] public RenderFragment<(int currentPage, int pageSize, EventCallback<ChangeEventArgs> onChanged, int[] options)>? PageSizeSelectorTemplate { get; set; }

    private int cartCount = 0;
    private PagedProductDtoResult? pagedResult;
    private int pageSize = 6;
    private int currentPage = 1;
    private readonly int[] pageSizes = [3, 6, 12, 24];

    protected override async Task OnInitializedAsync()
    {
        if (OnLoadPage is not null)
        {
            await LoadPage(1);
        }
    }

    private async Task LoadPage(int page)
    {
        currentPage = page;
        if (OnLoadPage is not null)
        {
            pagedResult = await OnLoadPage(page, pageSize);
        }
    }

    private async Task HandleAddToCart(Guid productId)
    {
        if (OnAddToCart is not null)
        {
            var result = await OnAddToCart(productId);

            if (result.Success)
            {
                cartCount = result.TotalItemsInCart;
                StateHasChanged();
            }
        }
    }

    private async Task OnPageSizeChanged(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out var newSize))
        {
            pageSize = newSize;
            await LoadPage(1);
        }
    }

    private async Task HandlePageChanged(int page) => await LoadPage(page);
}