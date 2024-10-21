using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.BookCategories;

public partial class BookCategoriesEndpoints
{
    private static async Task<IResult> UpdateBookCategory(
        int id,
        [FromBody] BookCategoryRequest request, 
        RepositoryContext repository)
    {
        // 輸入驗證
        var validationResult = new BookCategoryRequestValidator().Validate(request);
        if (validationResult.IsValid is false) 
            return TypedResults.BadRequest(validationResult.Errors);
        // 取出實體
        BookCategory? bookCategory = await repository.BookCategories
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        if (validationResult is null)
            return TypedResults.NotFound();
        // 變更實體
        bookCategory = request.Adapt(bookCategory);
        repository.BookCategories.Update(bookCategory);
        await repository.SaveChangesAsync();
        return TypedResults.Ok(bookCategory);
    }
}
