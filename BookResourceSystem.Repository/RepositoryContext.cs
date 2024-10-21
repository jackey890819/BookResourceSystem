using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // EFCore.CheckConstraints check constraints
        // https://github.com/efcore/EFCore.CheckConstraints
        optionsBuilder.UseValidationCheckConstraints(); // Validation constraints
        optionsBuilder.UseEnumCheckConstraints();       // Enum constraints
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookLanguageConfiguration());
        modelBuilder.ApplyConfiguration(new PublishingHouseConfiguration());
        modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }


    // 實體註冊
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookLanguage> BookLanguages {  get; set; }
    public DbSet<PublishingHouse> PublishingHouses {  get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<Book> Books { get; set; }


    // 複寫變更方法，支援針對需要紀錄時間的實體。
    public override int SaveChanges()
    {
        AddTimeTrack();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimeTrack();
        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>添加時間追蹤值</summary>
    private void AddTimeTrack()
    {
        foreach (var entry in ChangeTracker.Entries<TimeTrackedEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
                //entry.Entity.UpdatedAt = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.Now;
            }
        }
    }
}
