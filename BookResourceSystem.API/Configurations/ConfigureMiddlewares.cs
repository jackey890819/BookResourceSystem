using Microsoft.AspNetCore.Antiforgery;

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
        else
        {
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        // app.UseStaticFiles();
        // app.UseCookiePolicy();

        app.UseCors("CorsPolicy");

        // app.UseAuthentication();
        // app.UseAuthorization();
        // app.UseSession();
        // app.UseResponseCompression();
        // app.UseResponseCaching();

        //app.UseAntiforgery();

        // Temporarily disable Antiforgery
        //app.Use(async (context, next) =>
        //{
        //    var antiforgery = context.RequestServices.GetService<IAntiforgery>();
        //    var tokens = antiforgery.GetAndStoreTokens(context);

        //    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
        //        new CookieOptions { HttpOnly = false });

        //    await next();
        //});
    }
}
