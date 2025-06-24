using Shop.Domain.Common;

namespace Shop.Domain.Aggregators.Products;

public interface IProductRepository: IRepository<Product>
{
    PagedResult<Product> GetPaged(int page, int pageSize);
}
