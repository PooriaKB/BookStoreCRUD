using System.ComponentModel.DataAnnotations;
using Entities;

namespace Contracts.DTOs;
/// <summary>
/// DTO Class for adding a new Book
/// </summary>
public class BookAddRequest
{
    [Length(2,100)]
    public string? BookName { get; set; }

    public DateTime? ReleaseDate { get; set; }
    
    public List<string>? AuthorsName { get; set; }
    
    [Range(0,1000)]
    public double? Price { get; set; }

    public Book ToBook()
    {
        return new Book()
        {
            BookName = BookName,
            AuthorsName = AuthorsName,
            ReleaseDate = ReleaseDate,
            Price = Price
        };
    }
    
}