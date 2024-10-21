using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookResourceSystem.Entities.Models;

/// <summary>
/// 出版社
/// </summary>
public class PublishingHouse : TimeTrackedEntity
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Introduction { get; set; }

}

public record PublishingHouseCreateDto
{
    public required string Name { get; init; }
    public string? Introduction { get; init; }
}

public record PublishingHouseUpdateDto : PublishingHouseCreateDto
{
    public required Guid Id;
}
