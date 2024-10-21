
using Microsoft.OpenApi.Any;

namespace BookResourceSystem.API.Endpoints.BookLanguages;

public partial class BookLanguagesEndpoints : IEndpoint
{
    public void MapEndpoints(WebApplication endpoint)
    {
        var group = endpoint.MapGroup("/api/booklanguages")
            .WithTags("BookLanguages");

        group.MapGet("/{id:guid}", GetBookLanguageById)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "取得單一圖書語言";
                op.Description = "使用實體的主鍵取得指定的圖書語言資訊。";
                var param = op.Parameters;
                param[0].Description = "作者Guid";
                return op;
            });

        group.MapGet("/", GetBookLanguages)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "取得圖書語言列表";
                op.Description = "取得圖書語言列表。";
                return op;
            });

        group.MapPost("/", CreateBookLanguage)
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "新增圖書語言";
                op.Description = "新增一筆圖書語言資料到資料庫中。";
                return op;
            });

        group.MapPut("/{id:guid}", UpdateBookLanguage)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "更新圖書語言";
                op.Description = "針對現有的圖書語言進行更新。";
                return op;
            });

        group.MapDelete("/{id:guid}", DeleteBookLanguage)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "刪除圖書語言";
                op.Description = "自資料庫中刪除指定圖書語言。";
                return op;
            });
    }
}
