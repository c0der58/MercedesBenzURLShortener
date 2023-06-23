using MercedesURLShortener.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercedesURLShortener.Repository.Seeds
{
    public class UrlSeed : IEntityTypeConfiguration<UrlModel>
    {
        public void Configure(EntityTypeBuilder<UrlModel> builder)
        {
            builder.HasData(
            new UrlModel
            {
                Id = 1,
                ShortUrl = "https://mb.com/3Dbenz",
                CurrentUrl = "https://www.mercedes-benz.com.tr/passengercars/mercedes-benz-cars/car-configurator.html/motorization/CCci/TR/tr/GT-KLASSE/4-TUERER%20COUPE",
                Description = "Hayalinde ki Mercedes'i kendi zevkine göre tasarla",
                CreatedDate = DateTime.UtcNow
            });
        }
    }
}
