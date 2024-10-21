using BookResourceSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.PublishingHouses;

public partial class PublishingHousesEndpoints
{
    private static async Task<IResult> GetPublishingHouses(RepositoryContext repository)
    {
        var phs = await repository.PublishingHouses
            .AsNoTracking()
            .ToListAsync();
        return TypedResults.Ok(phs);
    }
}
