using MediatR;

public record GetProductsQuery(int Page, int PageSize) : IRequest<PagedProductDtoResult>;
