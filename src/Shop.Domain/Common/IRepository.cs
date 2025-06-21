using System.Threading.Tasks;

namespace Shop.Domain.Common;

public interface IRepository<TEntity> where TEntity : class
{
    Task SaveAsync(TEntity entity);
}
