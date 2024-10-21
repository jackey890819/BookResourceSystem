using System.ComponentModel.DataAnnotations;

namespace BookResourceSystem.Entities.Models;

/// <summary>
/// 圖書語言
/// </summary>
public class BookLanguage : TimeTrackedEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(20), MinLength(1)]
    public required string Name { get; set; }
}

public record BookLanguageCreateDto
{
    public required string Name { get; init; }
}

public record BookLanguageDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
}
