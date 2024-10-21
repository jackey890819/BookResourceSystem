using BookResourceSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookResourceSystem.Repository.Configurations;

internal class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.ToTable(t => t.HasComment("圖書分類"));
        builder.HasData
        (
            new BookCategory { Id = 1, Name = "分類A" },
            new BookCategory { Id = 2, Name = "分類B" },
            new BookCategory { Id = 3, Name = "分類C" }
        );
    }
}
