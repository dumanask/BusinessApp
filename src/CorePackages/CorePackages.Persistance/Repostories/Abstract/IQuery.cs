namespace CorePackages.Persistance.Repostories.Abstract;

public interface IQuery<TEntity>
{
    /// <summary>
    /// To be able to query entity object from db
    /// <typeparamref name="TEntity"/ presents Db object> 
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> Query();
}
