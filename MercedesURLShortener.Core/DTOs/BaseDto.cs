namespace MercedesURLShortener.Core.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
