namespace BookResourceSystem.API.Endpoints.PublishingHouses;

public partial class PublishingHousesEndpoints : IEndpoint
{
    public void MapEndpoints(WebApplication endpoint)
    {
        var group = endpoint.MapGroup("/api/publishinghouses")
            .WithTags("PublishingHouses");

        group.MapGet("/{id:guid}", GetPublishingHouseById)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "取得單一出版社";
                op.Description = "使用實體的主鍵取得指定的出版社資訊。";
                var param = op.Parameters;
                param[0].Description = "出版社Id";
                return op;
            });

        group.MapGet("/", GetPublishingHouses)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "取得出版社列表";
                op.Description = "根據參數取得相關的出版社列表。";
                return op;
            });

        group.MapPost("/", CreatePublishingHouse)
            .DisableAntiforgery()
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "新增出版社";
                op.Description = "新增一筆出版社到資料庫中。";
                return op;
            });

        group.MapPut("/{id:guid}", UpdatePublishingHouse)
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(op =>
            {
                op.Summary = "更新出版社";
                op.Description = "更新現有的出版社。";
                return op;
            });

        group.MapDelete("/{id:guid}", DeletePublishingHouse)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithOpenApi(op =>
            {
                op.Summary = "刪除出版社";
                op.Description = "自資料庫中刪除指定出版社。";
                return op;
            });
    }
}
