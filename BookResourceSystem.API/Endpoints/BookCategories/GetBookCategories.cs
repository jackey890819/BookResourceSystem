using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.BookCategories;

public partial class BookCategoriesEndpoints
{
    private static async Task<IResult> GetBookCategories(RepositoryContext repository)
    {
        List<BookCategory> bookCategory = await repository.BookCategories
            .AsNoTracking().ToListAsync();
        if (bookCategory.Count == 0) return TypedResults.NotFound();
        return TypedResults.Ok(bookCategory);
    }
}
