using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.PublishingHouses;

public partial class PublishingHousesEndpoints
{
    private static async Task<IResult> GetPublishingHouseById(Guid id, RepositoryContext repository)
    {
        PublishingHouse? ph = await repository.PublishingHouses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        if (ph is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(ph);
    }
}
