using System.Linq.Expressions;

namespace AskMe.Core.Core.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById<TEntity>(object id) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>(int? count) where TEntity : class;
        TEntity GetFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
        Task<TEntity> AddItem<TEntity>(TEntity item) where TEntity : class;
        Task<IEnumerable<TEntity>> AddItems<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
        IEnumerable<TEntity> GetAllBy<TEntity>(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : class;
        TEntity SoftDeleteEntity<TEntity>(TEntity entity) where TEntity : class;
        TEntity HardDeleteEntity<TEntity>(TEntity entity) where TEntity : class;
        TEntity UpdateEntity<TEntity>(TEntity entity) where TEntity : class;
        int Count<TEntity>() where TEntity : class;
    }
}
