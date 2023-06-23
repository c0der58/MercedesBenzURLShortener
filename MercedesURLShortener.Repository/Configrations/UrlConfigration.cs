using MercedesURLShortener.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercedesURLShortener.Repository.Configrations
{
    public class UrlConfigration : IEntityTypeConfiguration<UrlModel>
    {
        public void Configure(EntityTypeBuilder<UrlModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CurrentUrl).IsRequired().HasMaxLength(250);
            builder.Property(x => x.ShortUrl).IsRequired().HasMaxLength(50);

            builder.ToTable("Url");
        }
    }
}