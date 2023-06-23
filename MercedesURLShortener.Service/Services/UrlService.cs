using MercedesURLShortener.Core.IRepositories;
using MercedesURLShortener.Core.IServices;
using MercedesURLShortener.Core.IUnitOfWorks;
using MercedesURLShortener.Core.Models;

namespace MercedesURLShortener.Service.Services
{
    public class UrlService : Service<UrlModel>, IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IGenericRepository<UrlModel> repository, IUnitOfWork unitOfWork, IUrlRepository urlRepository) : base(unitOfWork, repository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<UrlModel> GetCurrentUrlByShortUrl(string shortUrl)
        {
            return await _urlRepository.GetCurrentUrlByShortUrl(shortUrl);
        }
    }
}