using Microsoft.AspNetCore.Components;

namespace Shop.UiLibrary.IntractiveComponents.Components
{
    public partial class ProductList
    {
        [Parameter] public PagedProductDtoResult PagedResult { get; set; } = default!;
        [Parameter] public EventCallback<int> OnPageChanged { get; set; }
        [Parameter] public EventCallback<Guid> OnAddToCart { get; set; }

        [Parameter] public RenderFragment<ProductDto>? ItemTemplate { get; set; }
        [Parameter] public RenderFragment<(int currentPage, int totalPages)>? PaginationTemplate { get; set; }

        private int TotalPages => (int)Math.Ceiling((double)PagedResult.TotalCount / PagedResult.PageSize);

        private async Task OnClickPage(int page)
        {
            if (page != PagedResult.Page)
            {
                await OnPageChanged.InvokeAsync(page);
            }
        }

        private static string GetRandomSvg(Guid id)
        {
            int seed = id.GetHashCode();
            var colors = new[] { "#FF6B6B", "#4ECDC4", "#FFD93D", "#5f27cd", "#1dd1a1" };
            var color = colors[Math.Abs(seed) % colors.Length];

            return $@"<svg width=""80"" height=""80"" xmlns=""http://www.w3.org/2000/svg"">
                    <circle cx=""40"" cy=""40"" r=""35"" fill=""{color}"" />
                    <text x=""50%"" y=""55%"" dominant-baseline=""middle"" text-anchor=""middle"" font-size=""16"" fill=""white"">P</text>
                </svg>";
        }
    }
}