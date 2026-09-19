using System.ComponentModel.DataAnnotations;
using Entities;

namespace Contracts.DTOs;
/// <summary>
/// DTO Class that is used as return type for most of CountriesServices
/// </summary>
public class BookResponse
{
    [Key]
    public Guid BookId { get; set; }
    
    [Length(2,100)]
    public string BookName { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public List<string>? AuthorsName { get; set; }

    public double? Price { get; set; }
    
}

public static class BookToBookResponseExtensions
{
    public static BookResponse ToBookResponse(this Book book)
    {
        return new BookResponse
        {
            BookId = book.BookId,
            BookName = book.BookName,
            ReleaseDate = book.ReleaseDate,
            AuthorsName = book.AuthorsName,
        };
    }
}