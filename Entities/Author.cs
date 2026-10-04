namespace Entities;

/// <summary>
/// Domain model for Authors
/// </summary>
public class Author
{
    public Guid AuthorId { get; set; }
    public string? AuthorName { get; set; }
}