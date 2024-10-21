using BookResourceSystem.Contracts.Extensions;
using BookResourceSystem.Entities.Models;
using BookResourceSystem.Repository;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookResourceSystem.API.Endpoints.PublishingHouses;

public partial class PublishingHousesEndpoints
{
    private record PublishingHouseRequest
    {
        public required string Name { get; set; }
        public string? Introduction { get; set; }
    }

    private class PublishingHouseRequestValidator : AbstractValidator<PublishingHouseRequest>
    {
        public PublishingHouseRequestValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("出版社名稱不可為空值！")
                .Length(1, 100)
                .WithMessage("出版社名稱為1~100個字！");
            RuleFor(e => e.Introduction)
                .MaximumLength(300)
                .WithMessage("簡介最多300個字！");
        }
    }

    private static async Task<IResult> CreatePublishingHouse(
        [FromBody]PublishingHouseRequest request,
        RepositoryContext repository)
    {
        var validationResult = new PublishingHouseRequestValidator().Validate(request);
        if (validationResult.IsValid is false)
            return TypedResults.BadRequest(validationResult.ToDictionary());

        PublishingHouse ph = request.Adapt<PublishingHouse>();
        repository.PublishingHouses.Add(ph);
        await repository.SaveChangesAsync();
        return TypedResults.Created($"/api/publishinghouses/{ph.Id}", ph);
    }
}
