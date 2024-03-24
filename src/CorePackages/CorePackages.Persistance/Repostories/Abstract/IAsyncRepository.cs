using CorePackages.Persistance.Domain;

namespace CorePackages.Persistance.Repostories.Abstract;

public interface IAsyncRepository<TEntity> : IQuery<TEntity>
where TEntity : BaseEntity
{
    Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
}
