namespace StagesCycling.DAL
{
    using System;
    using System.Data.Entity.Validation;
    using System.Threading.Tasks;
    using Context;
    using StagesCycling.DAL.Entities;
    using StagesCycling.DAL.Entities.Base;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryFactory _factory;

        public UnitOfWork(ApplicationDbContext context, IRepositoryFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Save()
        {
            try
            {
                 _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return _factory.CreateRepository<T>(_context);
        }
    }
}
