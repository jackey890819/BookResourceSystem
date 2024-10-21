using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookResourceSystem.API.Endpoints.Authors;

public partial class AuthorsEndpoints
{

    private static async Task<IResult> UpdateAuthor(Guid id, [FromBody] AuthorRequest request, RepositoryContext repository)
    {
        Author? author = await repository.Authors.FindAsync(id);
        if (author is null)
            return TypedResults.NotFound();

        var validationResult = new AuthorRequestValidator().Validate(request);
        if (validationResult.IsValid is false)
        {
            return TypedResults.BadRequest(validationResult.Errors);
        }
        // public static TDestination Adapt<TSource, TDestination>(this TSource source, TDestination destination)
        author = request.Adapt<AuthorRequest,Author>(author);
        repository.Authors.Update(author);
        await repository.SaveChangesAsync();

        return TypedResults.Ok(author);
    }
}
