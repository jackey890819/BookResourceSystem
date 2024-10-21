using System.ComponentModel.DataAnnotations;

namespace BookResourceSystem.Entities.Models;

/// <summary>
/// 圖書類別
/// </summary>
public class BookCategory : TimeTrackedEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100), MinLength(1)]
    public required string Name { get; set; }
}
