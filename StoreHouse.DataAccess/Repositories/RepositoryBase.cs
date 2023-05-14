using Microsoft.EntityFrameworkCore;
using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace StoreHouse.DataAccess.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        internal readonly DbSet<T> dbSet;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            dbSet.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            dbSet.RemoveRange(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
