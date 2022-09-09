using AskMe.Core.Core.Data.Context;
using AskMe.Core.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace AthenicConsulting.Core.Core.Models
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AskMeDbContext _context;
        public GenericRepository(AskMeDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddItem<TEntity>(TEntity item) where TEntity : class
        {
            var result = await _context.AddAsync(item);
            return result.Entity;
        }

        public IEnumerable<TEntity> GetAll<TEntity>(int? count) where TEntity : class
        {
            var query = _context.Set<TEntity>();
            if (count.HasValue)
            {
                query.AsQueryable().Take(count.Value);
            }


            return query.ToList();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            var query = await _context.Set<TEntity>().AsQueryable().ToListAsync();
            return query;
        }

        public IEnumerable<TEntity> GetAllBy<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "") where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById<TEntity>(object id) where TEntity : class
        {
            var query = _context.Set<TEntity>().AsQueryable();
            var result = query.FirstOrDefault(x => x.Equals(id));
            return result;
        }

        public TEntity GetFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (filter == null) { return query.FirstOrDefault(); }
            return query.FirstOrDefault(filter);
        }

        public TEntity UpdateEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var updatedEntity = _context.Set<TEntity>().Update(entity);
            return updatedEntity.Entity;
        }

        public TEntity SoftDeleteEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var updatedEntity = _context.Set<TEntity>().Update(entity);
            return updatedEntity.Entity;
        }

        public TEntity HardDeleteEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var removedEntity = _context.Set<TEntity>().Remove(entity);
            return removedEntity.Entity;
        }

        public async Task<IEnumerable<TEntity>> AddItems<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            var dbSet = _context.Set<TEntity>();
            await dbSet.AddRangeAsync(entities);
            return entities;
        }

        public int Count<TEntity>() where TEntity : class
        {
            var dbSet = _context.Set<TEntity>();
            return dbSet.Count();
        }
    }
}
