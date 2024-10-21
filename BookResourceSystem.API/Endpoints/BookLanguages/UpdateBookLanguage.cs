using BookResourceSystem.Contracts.Extensions;
using BookResourceSystem.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.BookLanguages;

public partial class BookLanguagesEndpoints
{

    private static async Task<IResult> UpdateBookLanguage(
        int id,
        [FromBody] BookLanguageRequest request,
        RepositoryContext repository)
    {
        var validationResult = new BookLanguageRequestValidator().Validate(request);
        if (validationResult.IsValid is false) return TypedResults.BadRequest(validationResult.ToDictionary());

        var bl = await repository.BookLanguages
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        if (bl is null) return TypedResults.NotFound();

        bl = request.Adapt(bl);
        repository.BookLanguages.Update(bl);
        await repository.SaveChangesAsync();

        return TypedResults.Ok(bl);
    }
}
