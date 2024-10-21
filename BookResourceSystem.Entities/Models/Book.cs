using System.ComponentModel.DataAnnotations;

namespace BookResourceSystem.Entities.Models;

/// <summary>
/// 圖書
/// </summary>
public class Book : TimeTrackedEntity
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Introduction { get; set; }

    public Author? Author { get; set; }
    public BookLanguage? BookLanguage { get; set; }
    public Book? OriginalBook {  get; set; }
    public PublishingHouse? PublishingHouse { get; set; }

}

public record BookDto
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public string? Introduction { get; init; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public record BookCreateDto
{
    public required string Name { get; init; }
    public string? Introduction { get; init; }
    public Guid? AuthorId { get; init; }
    public Guid? PublishingHouseId { get; init; }
    public int? BookLanguageId { get; init; }
    public Guid? OriginalBookId { get;init; }
}

public record BookUpdateDto : BookCreateDto
{
    public required Guid Id { get; init; }
}
