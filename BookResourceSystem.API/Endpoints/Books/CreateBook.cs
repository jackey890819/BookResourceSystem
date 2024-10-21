using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BookResourceSystem.API.Endpoints.Books;

public partial class BooksEndpoints
{
    private record CreateBookRequest
    {
        public required string Name { get; init; }
        public string? Introduction { get; init; } = null;
        public Guid? AuthorId { get; init; } = null;
        public Guid? PublishingHouseId { get; init; } = null;
        public int? BookLanguageId { get; init; } = null;
        public Guid? OriginalBookId { get; init; } = null;
    }

    private class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        /// <summary>
        /// 驗證器的建構式: 在這裡註冊我們要驗證的規則
        /// </summary>
        public CreateBookRequestValidator()
        {
            
        }
    }

    private static async Task<IResult> CreateBook([FromBody] CreateBookRequest request,
        RepositoryContext repository)
    {
        var validationResult = new CreateBookRequestValidator().Validate(request);
        if (validationResult.IsValid is false)
        {
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
            var resultMessage = string.Join(",", errorMessages);
            return TypedResults.BadRequest(resultMessage); // 直接回傳 400 + 錯誤訊息
        }

        Book book = request.Adapt<Book>();
        await repository.Books.AddAsync(book);
        return TypedResults.Ok(book);

    }
}
