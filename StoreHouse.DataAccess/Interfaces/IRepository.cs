using System.Linq.Expressions;

namespace StoreHouse.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(Expression<Func<T, bool>> filter);
        public Task Add(T entity);
        public Task Delete(T entity);
        public Task Remove(T entity);
        public Task RemoveRange(IEnumerable<T> entities);
    }
}
