
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookResourceSystem.Entities.Models;

/// <summary>
/// 出版社
/// </summary>
public class PublishingHouse
{
    [Key]
    public Guid Id { get; set; }
    public required string Name {  get; set; }
    public string? Introduction { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Inserted { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime LastUpdated { get; set; }
}
