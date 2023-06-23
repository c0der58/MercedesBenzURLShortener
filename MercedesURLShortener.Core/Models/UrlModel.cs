namespace MercedesURLShortener.Core.Models
{
    public class UrlModel : BaseModel
    {
        public string CurrentUrl { get; set; }
        public string ShortUrl { get; set; }
        public int VisitorCount { get; set; }
        public string? Description { get; set; }

    }
}
