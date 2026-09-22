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
    public string? BookName { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public List<string>? AuthorsName { get; set; }

    public double? Price { get; set; }

    public override bool Equals(object? obj)
    {
        if( obj == null || GetType() != obj.GetType() )
            return false;
        
        BookResponse bookResponse = (BookResponse)obj;

        return BookId == bookResponse.BookId && BookName == bookResponse.BookName
                                             && ReleaseDate == bookResponse.ReleaseDate;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
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