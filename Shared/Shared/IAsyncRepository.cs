using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public interface IAsyncRepository<TEntity, TId>
{
    Task<TEntity> AddAsync(TEntity entity);

    Task<List<TEntity>> AddListAsync(List<TEntity> entities);
    
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,object>>? include=null);
    
    Task<TEntity> GetById(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default);

    Task<TEntity> UpdateAsync(TEntity entity);
    Task<List<TEntity>> UpdateListAsync(List<TEntity> entities);
    Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false);
    Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entities, bool permanent = false);
}
