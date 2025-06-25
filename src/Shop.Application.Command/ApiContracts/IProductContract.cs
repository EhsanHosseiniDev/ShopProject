namespace Shop.Application.Command.ApiContracts;

public interface IProductContract
{
    Task<PagedProductDtoResult> GetProductsQuery(int Page, int PageSize);
}
