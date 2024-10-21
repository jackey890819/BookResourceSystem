namespace BookResourceSystem.API.Endpoints.Books;

public partial class BooksEndpoints : IEndpoint
{
    public void MapEndpoints(WebApplication endpoint)
    {
        var group = endpoint.MapGroup("/api/books").WithTags("Books");

        // 查詢
        group.MapGet("/{id:guid}", GetBookById)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "取得單一圖書";
                return op;
            });

        group.MapGet("/", GetBooks)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "取得圖書列表。";
                return op;
            });
        // 建立
        group.MapPost("/", CreateBook)
            .Produces(StatusCodes.Status201Created)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "新增圖書";
                return op;
            });
        // 更新
        group.MapPut("/", UpdateBook)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "更新指定圖書";
                return op;
            });
        // 刪除
        group.MapDelete("/", DeleteBook)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "刪除指定圖書";
                return op;
            });
    }
}
