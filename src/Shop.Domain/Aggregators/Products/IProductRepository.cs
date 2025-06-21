using Shop.Domain.Common;
using System;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregators.Products;

public interface IProductRepository: IRepository<Product>
{
    Task<Product> GetByIdAsync(Guid productId);
    Task<PagedResult<Product>> GetPagedAsync(int page, int pageSize);
}
