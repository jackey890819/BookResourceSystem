using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;

namespace BookResourceSystem.API.Endpoints.Authors;

public partial class AuthorsEndpoints
{

    private static async Task<IResult> DeleteAuthor(Guid id, RepositoryContext repository)
    {
        Author? author = await repository.Authors.FindAsync(id);
        if (author is null)
            return TypedResults.NotFound();

        repository.Authors.Remove(author);
        await repository.SaveChangesAsync();

        return TypedResults.Ok(author);
    }
}
