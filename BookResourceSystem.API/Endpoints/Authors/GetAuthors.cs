using BookResourceSystem.Entities;
using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.Authors;

public partial class AuthorsEndpoints
{
    private class GetAuthorRequest : RequestParameters
    {
        public GetAuthorRequest() : base() { }
    }

    private static async Task<IResult> GetAuthors([AsParameters] GetAuthorRequest request, RepositoryContext repository)
    {
        List<Author> authors = await repository.Authors
            .AsNoTracking()
            .OrderBy(e => e.CreatedAt)
            .Skip((request.GetPageNumber() - 1) * request.GetPageSize())
            .Take(request.GetPageSize())
            .ToListAsync();

        if (authors.Count == 0) return TypedResults.NotFound();

        return TypedResults.Ok(authors);
    }
}