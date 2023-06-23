using MercedesURLShortener.Core.IRepositories;
using MercedesURLShortener.Core.IServices;
using MercedesURLShortener.Core.IUnitOfWorks;
using System.Linq.Expressions;

namespace MercedesURLShortener.Service.Services
{
    public class Service<T> : IServices<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            return await _repository.RemoveAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
