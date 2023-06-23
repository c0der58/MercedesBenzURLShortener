using System.Linq.Expressions;

namespace MercedesURLShortener.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
