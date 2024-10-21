using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.BookCategories;

public partial class BookCategoriesEndpoints
{
    private static async Task<IResult> GetBookCategoryById(int id, RepositoryContext repository)
    {
        BookCategory? bookCategory = await repository.BookCategories
            .AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        if (bookCategory is null) return TypedResults.NotFound();
        return TypedResults.Ok(bookCategory);
    }
}
