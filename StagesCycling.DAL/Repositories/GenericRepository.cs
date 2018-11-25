namespace StagesCycling.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Entities.Base;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        private IDbSet<TEntity> _entities;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public IDbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());       

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public virtual TEntity Get(long id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public virtual TEntity Create(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return Entities.Add(item);
        }
        public virtual void Update(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

             _context.Entry(item).State = EntityState.Modified;
        }

        public virtual TEntity Delete(long id)
        {
            var entity = _context.Set<TEntity>().Find(id);

            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }

            return entity;
        }

        public virtual void Delete(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

              _context.Entry(item).State = EntityState.Deleted;
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            IEnumerable<TEntity> query = _context.Set<TEntity>().Where(filter);
           // query = query.Where(filter);
            return query;
        }

        public IQueryable<TEntity> Query => Entities;
    }
}
