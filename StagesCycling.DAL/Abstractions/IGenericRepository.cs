namespace StagesCycling.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using StagesCycling.DAL.Entities;

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        TEntity Create(TEntity item);
        void Update(TEntity item);
        TEntity Delete(long id);
        void Delete(TEntity item);

        IQueryable<TEntity> Query { get; }
        IDbSet<TEntity> Entities { get; }
    }
}
