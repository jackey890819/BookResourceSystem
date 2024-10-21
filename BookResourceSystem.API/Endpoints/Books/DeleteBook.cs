using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BookResourceSystem.API.Endpoints.Books;

public partial class BooksEndpoints
{
    /// <summary>
    /// 刪除指定id的圖書實體
    /// </summary>
    /// <param name="id">圖書實體的Guid</param>
    /// <returns></returns>
    private static async Task<IResult> DeleteBook(Guid id, RepositoryContext repository)
    {
        var entity = await repository.Books.FindAsync(id);
        if (entity is null)
            return TypedResults.NotFound();
        
        repository.Books.Remove(entity);
        await repository.SaveChangesAsync();
        return TypedResults.Ok();

    }
}
