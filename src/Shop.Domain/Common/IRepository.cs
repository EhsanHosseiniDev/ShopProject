using System;

namespace Shop.Domain.Common;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity? Find(Guid entityId);
    void Add(TEntity entity);
}
