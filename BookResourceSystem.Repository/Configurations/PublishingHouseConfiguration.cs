using BookResourceSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookResourceSystem.Repository.Configurations;

internal class PublishingHouseConfiguration : IEntityTypeConfiguration<PublishingHouse>
{
    public void Configure(EntityTypeBuilder<PublishingHouse> builder)
    {
        builder.ToTable(t => t.HasComment("出版社實體"));
        builder.HasData
        (
            new PublishingHouse { Id = Guid.Parse("7b810218-da4f-49c9-a2a8-11d34fd58f4f"), Name = "測試出版社A", Introduction = "測試出版社A資訊" },
            new PublishingHouse { Id = Guid.Parse("0b683c48-7f19-4025-9fb6-996e36629e25"), Name = "測試出版社B" }
        );
    }
}
