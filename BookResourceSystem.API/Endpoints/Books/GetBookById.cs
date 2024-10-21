using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BookResourceSystem.API.Endpoints.Books
{
    public partial class BooksEndpoints
    {
        /// <summary>
        /// 透過Guid取得單一圖書
        /// </summary>
        /// <param name="id">圖書的Guid</param>
        /// <returns>圖書物件</returns>
        private static async Task<IResult> GetBookById(Guid id, RepositoryContext repository)
        {
            Book? book = await repository.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            if (book is null)
                return TypedResults.NotFound();
            BookDto bookDto = book.Adapt<BookDto>();
            return TypedResults.Ok(bookDto);
        }
    }
}
