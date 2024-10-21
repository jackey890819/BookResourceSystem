using BookResourceSystem.Entities;
using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookResourceSystem.API.Endpoints.Books;

public partial class BooksEndpoints
{
    /// <summary>
    /// 查詢多個圖書用的參數物件
    /// </summary>
    private class GetBookRequest : RequestParameters
    {
        public GetBookRequest() : base() { }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static async Task<IResult> GetBooks(HttpContext httpContext, RepositoryContext repository)
    {
        var request = httpContext.Request.Query.Adapt<GetBookRequest>();

        List<Book> books = await repository.Books
            .AsNoTracking()
            .OrderBy(e => e.CreatedAt)
            .Skip((request.GetPageNumber() - 1) * request.GetPageSize())
            .Take(request.GetPageSize())
            .ToListAsync();

        if (books.Count == 0) return TypedResults.NotFound();

        List<BookDto> bookDtos = books.Adapt<List<BookDto>>();
        return TypedResults.Ok(bookDtos);
    }
}
