using MediatR;
using Shop.Domain.Aggregators.Products;

public class GetProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductsQuery, PagedProductDtoResult>
{
    public async Task<PagedProductDtoResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await productRepository.GetPagedAsync(request.Page, request.PageSize);

        var dtos = allProducts.Items.Select(p => new ProductDto(
            p.Id,
            p.Name,
            p.Price,
            p.Quantity
        )).ToList();

        return new PagedProductDtoResult(dtos, allProducts.TotalCount, request.Page, request.PageSize);
    }
}
