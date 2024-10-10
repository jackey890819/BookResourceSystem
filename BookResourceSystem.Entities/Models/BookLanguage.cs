using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookResourceSystem.Entities.Models;

public class BookLanguage
{
    [Key]
    public int Id { get; set; }
    [MaxLength(20), MinLength(1)]
    public required string Name { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Inserted { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime LastUpdated { get; set; }
}
