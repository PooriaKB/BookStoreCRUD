using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Book
{
    [Key]
    public Guid BookId { get; set; }
    
    [Length(2,100)]
    public string? BookName { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public List<string>? AuthorsName { get; set; }

    [Range(0,1000)]
    public double? Price { get; set; }
}