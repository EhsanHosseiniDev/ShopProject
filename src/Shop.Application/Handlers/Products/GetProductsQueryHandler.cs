using MediatR;
using Shop.Domain.Aggregators.Products;

public class GetProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductsQuery, PagedProductDtoResult>
{
    public Task<PagedProductDtoResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var allProducts = productRepository.GetPaged(request.Page, request.PageSize);

        var dtos = allProducts.Items.Select(p => new ProductDto(
            p.Id,
            p.Name,
            p.Price,
            p.Quantity
        )).ToList();

        return Task.FromResult(new PagedProductDtoResult(dtos, allProducts.TotalCount, request.Page, request.PageSize));
    }
}
