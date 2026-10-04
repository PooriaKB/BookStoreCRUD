using System.ComponentModel.DataAnnotations;
using Entities;

namespace Contracts.DTOs;
/// <summary>
/// DTO Class for adding a new Book
/// </summary>
public class BookAddRequest
{
    [Length(2,100)]
    [Required(ErrorMessage = "book name can't be empty")]
    public string? BookName { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime? ReleaseDate { get; set; }
    
    public List<string>? AuthorsName { get; set; }
    
    /// <summary>
    ///  Convert current obj of BookAddRequest to Book obj
    /// </summary>
    /// <returns>Book obj form convert</returns>
    public Book ToBook()
    {
        return new Book()
        {
            BookName = BookName,
            AuthorsName = AuthorsName,
            ReleaseDate = ReleaseDate
        };
    }
    
}