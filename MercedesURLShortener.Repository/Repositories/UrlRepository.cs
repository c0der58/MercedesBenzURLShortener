using MercedesURLShortener.Core.IRepositories;
using MercedesURLShortener.Core.Models;
using MercedesURLShortener.Repository;
using MercedesURLShortener.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MercedesURLShortener.Repository.Repostories
{
    public class UrlRepository : GenericRepository<UrlModel>, IUrlRepository
    {
        public UrlRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<UrlModel> GetCurrentUrlByShortUrl(string shortUrl)
        {
            return await _context.Url.Where(x => x.ShortUrl == shortUrl).FirstOrDefaultAsync();
        }
    }
}
