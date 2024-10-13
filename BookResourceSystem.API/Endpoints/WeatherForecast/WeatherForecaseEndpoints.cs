using BookResourceSystem.Contracts.Repository;


namespace BookResourceSystem.API.Endpoints.WeatherForecast;

public class WeatherForecaseEndpoints : IEndpoint
{
        
    public void MapEndpoints(IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();

        endpoint.MapGet("/test", (IRepositoryManager repository) =>
        {
            return repository.Author.FindAll(false).ToList();
        })
        .WithName("Test")
        .WithOpenApi();
    }

    static string[] summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

}
