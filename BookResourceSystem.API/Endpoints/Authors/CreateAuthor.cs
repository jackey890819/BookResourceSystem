using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookResourceSystem.API.Endpoints.Authors;

public partial class AuthorsEndpoints
{
    private record AuthorRequest
    {
        public required string Name { get; init; }
        public string? Introduction { get; init; }
    }

    private class AuthorRequestValidator : AbstractValidator<AuthorRequest>
    {
        /// <summary>
        /// 驗證器的建構式: 在這裡註冊我們要驗證的規則
        /// </summary>
        public AuthorRequestValidator()
        {
            this.RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("作者姓名不可為空值！")
                .Length(1, 50)
                .WithMessage("作者姓名為1~50個字！");

            this.RuleFor(e => e.Introduction)
                .MaximumLength(300)
                .WithMessage("作者簡介最長為300的字！");
        }
    }

    private static async Task<IResult> CreateAuthor([FromBody] AuthorRequest request, RepositoryContext repository)
    {
        var validationResult = new AuthorRequestValidator().Validate(request);
        if (validationResult.IsValid is false)
        {
            return TypedResults.BadRequest(validationResult.Errors);
        }

        Author author = request.Adapt<Author>();
        await repository.Authors.AddAsync(author);
        await repository.SaveChangesAsync();
        return TypedResults.Created($"/authors/{author.Id}", author);
    }
}
