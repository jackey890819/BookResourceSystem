using BookResourceSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookResourceSystem.Repository.Configurations;

internal class BookLanguageConfiguration : IEntityTypeConfiguration<BookLanguage>
{
    public void Configure(EntityTypeBuilder<BookLanguage> builder)
    {
        builder.ToTable(t => t.HasComment("圖書語言"));
        builder.HasData
        (
            new BookLanguage { Id = 1, Name = "繁體中文" },
            new BookLanguage { Id = 2, Name = "英文" },
            new BookLanguage { Id = 3, Name = "簡體中文" }
        );
    }
}
