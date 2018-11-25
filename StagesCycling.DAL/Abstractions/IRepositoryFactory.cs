namespace StagesCycling.DAL
{
    using StagesCycling.DAL.Context;

    public interface IRepositoryFactory
    {
        IGenericRepository<T> CreateRepository<T>(ApplicationDbContext context) where T : class;
    }
}
