using BookResourceSystem.API.Endpoints;

namespace BookResourceSystem.API.Configurations;

public static partial class Configurations
{
    public static void ConfigureEndpoints(this WebApplication app)
    {
        // 掃描並映射所有實作 IEndpoint 的類別
        var endpointTypes = typeof(Program).Assembly
            .GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
        // 逐一註冊
        foreach (var type in endpointTypes)
        {
            var endpoint = (IEndpoint)Activator.CreateInstance(type)!;
            endpoint.MapEndpoints(app);
        }
    }
}
