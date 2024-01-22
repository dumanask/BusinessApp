using BusinessApp.Shared.Application.Services;
using BusinessApp.Shared.Domain.Models.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Shared.Persistance.Repositories;

public class EfAsyncRepository<TEntity, TContext> : IAsyncRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected TContext _context;
    public EfAsyncRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        //entity.CreatedDate = DateTime.UtcNow;
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> AddListAsync(List<TEntity> entities)
    {
        //foreach (TEntity entity in entities)
        //    entity.CreatedDate = DateTime.UtcNow;
        await _context.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var data = _context.Set<TEntity>().AsQueryable();
        if (include != null)
            data = include(data);

        var result = await data.Where(predicate).FirstOrDefaultAsync();

        return result;
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        var data = _context.Set<TEntity>().AsQueryable();
        if (!enableTracking)
            data = data.AsNoTracking();
        if (predicate != null)
            data = data.Where(predicate);
        if (orderBy != null)
            data = orderBy(data);
        if (include != null)
            data = include(data);

        return await data.ToListAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> UpdateListAsync(List<TEntity> entities)
    {
        foreach (TEntity entity in entities)
            entity.UpdatedDate = DateTime.UtcNow;
        _context.UpdateRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
    {
        entity.DeletedDate = DateTime.UtcNow;
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entities, bool permanent = false)
    {
        //await SetEntityAsDeletedAsync(entities, permanent);
        foreach (TEntity entity in entities)
            entity.DeletedDate = DateTime.UtcNow;
        _context.RemoveRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    /*
    protected async Task SetEntityAsDeletedAsync(TEntity entity, bool permanent)
    {
        if (!permanent)
        {
            CheckHasEntityHaveOneToOneRelation(entity);
            await setEntityAsSoftDeletedAsync(entity);
        }
        else
        {
            _context.Remove(entity);
        }
    }
    */
}
