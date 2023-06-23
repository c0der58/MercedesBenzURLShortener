namespace MercedesURLShortener.Core.DTOs
{
    public class UrlDto : BaseDto
    {
        public string CurrentUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}
