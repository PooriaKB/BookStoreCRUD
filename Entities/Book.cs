using System.ComponentModel.DataAnnotations;

namespace Entities;

/// <summary>
/// Domain Model for Book
/// </summary>
public class Book
{
    public Guid BookId { get; set; }
    public string? BookName { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public List<string>? AuthorsName { get; set; }
}