using FluentValidation.Results;

namespace BookResourceSystem.Contracts.Extensions;
/// <summary>
/// 自定義錯誤資訊物件。(擷取自FluentValidation.Results.ValidationFailure)
/// </summary>
public record ErrorObject
{
    public required string PropertyName { get; init; }
    public required string ErrorMessage { get; init; }
}

public static class FluentValidationExtension
{
    /// <summary>
    /// 取得自定義的錯誤資訊物件列表。
    /// </summary>
    public static List<ErrorObject> GetListOfError(this List<ValidationFailure> errors)
    {
        return errors.Select(e => new ErrorObject
        {
            PropertyName = e.PropertyName,
            ErrorMessage = e.ErrorMessage
        }).ToList();
    }

    public static IDictionary<string, string[]> ToDictionary(this ValidationResult validationResult)
    {
        return validationResult.Errors
            .GroupBy(x => x.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
            );
    }
}
