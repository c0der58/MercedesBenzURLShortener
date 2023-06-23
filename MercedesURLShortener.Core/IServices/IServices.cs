using System.Linq.Expressions;

namespace MercedesURLShortener.Core.IServices
{
    public interface IServices<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
