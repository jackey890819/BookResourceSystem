
using BookResourceSystem.Contracts.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using System.Security.AccessControl;

namespace BookResourceSystem.API.Endpoints.Books;

public class BooksEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("/api/books", GetBookById);
    }

    private static async Task<IResult> GetBookById(IRepositoryManager repository, Guid id)
    {
        
        throw new NotImplementedException();
    }
}


