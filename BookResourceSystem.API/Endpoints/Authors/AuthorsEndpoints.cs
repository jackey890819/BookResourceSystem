using Microsoft.OpenApi.Any;

namespace BookResourceSystem.API.Endpoints.Authors;

public partial class AuthorsEndpoints : IEndpoint
{
    public void MapEndpoints(WebApplication endpoint)
    {
        var group = endpoint.MapGroup("/api/authors")
            .WithTags("Authors");

        group.MapGet("/{id:guid}", GetAuthorById)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
             {
                 op.Summary = "取得單一作者";
                 op.Description = "使用實體的主鍵取得指定的作者資訊。";
                 var param = op.Parameters;
                 param[0].Description = "作者Guid";
                 param[0].Example = new OpenApiString("2f8ecdce-de59-4bd1-bf85-2339efaf2d3e");
                 return op;
             });

        group.MapGet("/", GetAuthors)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "取得作者列表";
                op.Description = "根據參數取得相關的作者列表。";
                return op;
            });

        group.MapPost("/", CreateAuthor)
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "新增作者";
                op.Description = "新增一筆作者資料到資料庫中。";
                // 複雜的回應格式範例
                //op.Responses = new OpenApiResponses()
                //{
                //    ["201"] = new OpenApiResponse()
                //    {
                //        Description = "成功新增"
                //    }
                //};
                return op;
            });

        group.MapPut("/{id:guid}", UpdateAuthor)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "更新作者";
                op.Description = "針對現有的作者進行更新。";
                return op;
            });

        group.MapDelete("/{id:guid}", DeleteAuthor)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "刪除作者";
                op.Description = "自資料庫中刪除指定作者。";
                return op;
            });
    }
}
