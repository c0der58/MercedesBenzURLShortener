using MercedesURLShortener.Core.Models;

namespace MercedesURLShortener.Core.IServices
{
    public interface IUrlService : IServices<UrlModel>
    {
        Task<UrlModel> GetCurrentUrlByShortUrl(string shortUrl);
    }
}