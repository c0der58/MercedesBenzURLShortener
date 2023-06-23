using MercedesURLShortener.Core.Models;

namespace MercedesURLShortener.Core.IRepositories
{
    public interface IUrlRepository : IGenericRepository<UrlModel>
    {
        public Task<UrlModel> GetCurrentUrlByShortUrl(string shortUrl);
    }
}