using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookResourceSystem.Entities.Models;

/// <summary>
/// 圖書
/// </summary>
public class Book
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Introduction { get; set; }

    public Author? Author { get; set; }
    public BookLanguage? BookLanguage { get; set; }
    public Book? OriginalBook {  get; set; }
    public PublishingHouse? PublishingHouse { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Inserted { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime LastUpdated { get; set; }

}
