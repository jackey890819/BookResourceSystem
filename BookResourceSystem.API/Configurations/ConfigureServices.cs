using BookResourceSystem.Contracts.Repository;
using BookResourceSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Configurations;

/// <summary>
/// 用於集中管理系統service
/// </summary>
public static partial class Configurations
{
    /// <summary>
    /// 設定系統的service
    /// </summary>
    /// <param name="builder"></param>
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // 資料庫
        builder.Services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("BookResourceSystem.API"))
        );

        // Repository
        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

    }
}
