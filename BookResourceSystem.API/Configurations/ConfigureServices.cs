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
        // CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            //.WithExposedHeaders("X-Pagination")
            );
        });

        //builder.Services.AddAntiforgery();

        //builder.Services.AddAntiforgery(options =>
        //{
        //    // 设置防伪令牌的标头名称
        //    options.HeaderName = "X-XSRF-TOKEN";
        //});

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // 資料庫
        builder.Services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("BookResourceSystem.API"))
        );
    }
}
