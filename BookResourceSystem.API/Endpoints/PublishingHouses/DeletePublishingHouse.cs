using BookResourceSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.PublishingHouses;

public partial class PublishingHousesEndpoints
{
    private static async Task<IResult> DeletePublishingHouse(Guid id, RepositoryContext repository)
    {
        var ph = await repository.PublishingHouses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        if (ph is null) return TypedResults.NotFound();
        
        repository.PublishingHouses.Remove(ph);
        await repository.SaveChangesAsync();
        return TypedResults.NoContent();
    }
}
