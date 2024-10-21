using BookResourceSystem.Contracts.Extensions;
using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookResourceSystem.API.Endpoints.BookLanguages;

public partial class BookLanguagesEndpoints
{
    private record BookLanguageRequest
    {
        //[MaxLength(20), MinLength(1)]
        public required string Name { get; set; }
    }

    private class BookLanguageRequestValidator : AbstractValidator<BookLanguageRequest>
    {
        public BookLanguageRequestValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("語言名稱不可為空！")
                .Length(1, 20)
                .WithMessage("語言名稱長度為1~20個字！");
        }
    }
    private static async Task<IResult> CreateBookLanguage(
        [FromBody] BookLanguageRequest request,
        RepositoryContext repository)
    {
        var validationResult = new BookLanguageRequestValidator().Validate(request);
        if (validationResult.IsValid is false) return TypedResults.BadRequest(validationResult.ToDictionary());

        var bl = request.Adapt<BookLanguage>();
        repository.BookLanguages.Add(bl);
        await repository.SaveChangesAsync();
        return TypedResults.Created($"/api/booklanguages/{bl.Id}", bl);
    }
}
