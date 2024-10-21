using BookResourceSystem.Contracts.Extensions;
using BookResourceSystem.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.BookLanguages;

public partial class BookLanguagesEndpoints
{

    private static async Task<IResult> GetBookLanguageById(
        int id,
        RepositoryContext repository)
    {
        var bl = await repository.BookLanguages
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        if (bl is null) return TypedResults.NotFound();
        return TypedResults.Ok(bl);
    }
}
