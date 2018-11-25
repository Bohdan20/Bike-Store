namespace StagesCycling.DAL
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        void Save();
    }
}
