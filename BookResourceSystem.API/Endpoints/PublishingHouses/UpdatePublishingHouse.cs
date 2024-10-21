using BookResourceSystem.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.PublishingHouses;

public partial class PublishingHousesEndpoints
{
    private static async Task<IResult> UpdatePublishingHouse(
        Guid id, 
        PublishingHouseRequest request,
        RepositoryContext repository)
    {
        var validationResult = new PublishingHouseRequestValidator().Validate(request);
        if (validationResult.IsValid is false)
            return TypedResults.BadRequest(validationResult.ToDictionary());
        
        var ph = await repository.PublishingHouses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        if (ph is null) return TypedResults.NotFound();

        ph = request.Adapt(ph);
        repository.PublishingHouses.Update(ph);
        await repository.SaveChangesAsync();
        return TypedResults.Ok(ph);
    }
}
