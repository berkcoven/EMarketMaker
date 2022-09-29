using System.Linq.Expressions;

namespace EMarketMaker.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);    
        void Update(T entity);//memory takip edildiği için hızlı oluyor Async yok
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
