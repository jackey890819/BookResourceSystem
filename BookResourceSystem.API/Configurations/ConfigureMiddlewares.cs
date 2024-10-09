namespace BookResourceSystem.API.Configurations;

/// <summary>
/// 用於集中管理系統middleware
/// </summary>
public static partial class Configurations
{
    /// <summary>
    /// 設定系統的middleware
    /// </summary>
    /// <param name="app"></param>
    public static void ConfigureMiddlewares(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHsts();
        app.UseHttpsRedirection();
    }
}
