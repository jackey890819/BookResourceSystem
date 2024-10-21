using BookResourceSystem.Contracts.Extensions;
using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookResourceSystem.API.Endpoints.BookCategories;

public partial class BookCategoriesEndpoints
{
    private record BookCategoryRequest
    {
        //[MaxLength(100), MinLength(1)]
        public required string Name { get; set; }
    }

    private class BookCategoryRequestValidator : AbstractValidator<BookCategoryRequest>
    {
        public BookCategoryRequestValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("圖書分類名稱不可為空值！")
                .Length(1, 100)
                .WithMessage("圖書分類為1~100個字！");
        }
    }

    private static async Task<IResult> CreateBookCategory([FromBody] BookCategoryRequest request, RepositoryContext repository)
    {
        // 驗證
        var validationResult = new BookCategoryRequestValidator().Validate(request);
        if (validationResult.IsValid is false)
        {
            return TypedResults.BadRequest(validationResult.ToDictionary());
        }
        // 重複檢查
        BookCategory? existed = await repository.BookCategories
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Name == request.Name);
        if (existed is not null) return TypedResults.BadRequest($"已存在分類\"{existed.Name}\"");
        // 新增
        BookCategory bookCategory = request.Adapt<BookCategory>();
        repository.Add(bookCategory);
        await repository.SaveChangesAsync();               
        return TypedResults.Created($"/bookcategories/{bookCategory.Id}", bookCategory);
    }
}
