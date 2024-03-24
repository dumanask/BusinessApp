using CorePackages.Persistance.Domain;
using CorePackages.Persistance.Repostories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CorePackages.Persistance.Repostories.Concrete;

public class EfAsyncRepository<TEntity, TContext> : IAsyncRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    private readonly TContext _context;

    public EfAsyncRepository(TContext context)
    {
        _context = context;
    }
    public IQueryable<TEntity> Query() => _context.Set<TEntity>();

    public async Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(entity);
        return await _context.SaveChangesAsync(cancellationToken);

    }

}
