using System.ComponentModel.DataAnnotations;
namespace BookResourceSystem.Entities.Models;

/// <summary>
/// 作者
/// </summary>
public class Author : TimeTrackedEntity
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Introduction { get; set; }
}

public class AuthorCreateDto
{
    public required string Name { get; init; }
    public string? Introduction { get; init; }
}

public class AuthorDto : Author
{
}

public class AuthorUpdateDto
{
    public string? Name { get; init; }
    public string? Introduction { get; init; }
}
