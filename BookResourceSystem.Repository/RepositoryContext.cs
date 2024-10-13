using BookResourceSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<BookLanguage> BookLanguages {  get; set; }
    public DbSet<PublishingHouse> PublishingHouses {  get; set; }
    public DbSet<Book> Books { get; set; }
}
