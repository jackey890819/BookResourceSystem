namespace BookResourceSystem.API.Endpoints;

/// <summary>
/// 用於自動Map所有專案中的端點的介面
/// </summary>
public interface IEndpoint
{
    /// <summary>
    /// 註冊端點
    /// </summary>
    /// <param name="endpoint"></param>
    void MapEndpoints(IEndpointRouteBuilder endpoint);
}
