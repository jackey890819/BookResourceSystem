using BookResourceSystem.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.Authors;

public partial class AuthorsEndpoints
{
    private static async Task<IResult> GetAuthorById(Guid id, RepositoryContext repository)
    {
        var author = await repository.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (author is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(author);
    }
}
