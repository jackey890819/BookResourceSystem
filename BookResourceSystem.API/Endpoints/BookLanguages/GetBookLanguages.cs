using BookResourceSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.BookLanguages;

public partial class BookLanguagesEndpoints
{
    private static async Task<IResult> GetBookLanguages(RepositoryContext repository)
    {
        var bl = await repository.BookLanguages
            .AsNoTracking()
            .ToListAsync();
        return TypedResults.Ok(bl);
    }
}
