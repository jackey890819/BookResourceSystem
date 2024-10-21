using Microsoft.OpenApi.Any;

namespace BookResourceSystem.API.Endpoints.BookCategories;

public partial class BookCategoriesEndpoints : IEndpoint
{
    public void MapEndpoints(WebApplication endpoint)
    {
        var group = endpoint.MapGroup("/api/bookCategories")
            .WithTags("BookCategories");

        group.MapGet("/{id:int}", GetBookCategoryById)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "取得單一分類";
                op.Description = "使用實體的主鍵取得指定的分類資訊。";
                var param = op.Parameters;
                param[0].Description = "圖書分類Id";
                return op;
            });

        group.MapGet("/", GetBookCategories)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "取得分類列表";
                op.Description = "根據參數取得相關的分類列表。";
                return op;
            });

        group.MapPost("/", CreateBookCategory)
            .DisableAntiforgery()
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "新增圖書分類";
                op.Description = "新增一筆圖書分類到資料庫中。";
                return op;
            });

        group.MapPut("/{id:int}", UpdateBookCategory)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "更新圖書分類";
                op.Description = "更新現有的圖書分類。";
                return op;
            });

        group.MapDelete("/{id:int}", DeleteBookCategory)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "刪除圖書分類";
                op.Description = "自資料庫中刪除指定圖書分類。";
                return op;
            });
    }
}
