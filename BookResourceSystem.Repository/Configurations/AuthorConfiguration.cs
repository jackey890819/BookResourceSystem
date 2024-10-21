using BookResourceSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookResourceSystem.Repository.Configurations;

internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(t => t.HasComment("作者實體"));
        builder.HasData
        (
            new Author { Id = Guid.Parse("2f8ecdce-de59-4bd1-bf85-2339efaf2d3e"), Name = "測試作者A" },
            new Author { Id = Guid.Parse("502a096f-402e-4e5d-b797-661c80cef1fc"), Name = "測試作者B" },
            new Author { Id = Guid.Parse("fcecfd23-beb0-4079-acd5-37b2c1fd97a9"), Name = "測試作者C" }
        );
    }
}
