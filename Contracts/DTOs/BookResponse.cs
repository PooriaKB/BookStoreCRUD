using System.ComponentModel.DataAnnotations;
using Entities;

namespace Contracts.DTOs;
/// <summary>
/// DTO Class that is used as return type for most of BookServices
/// </summary>
public class BookResponse
{
    public Guid BookId { get; set; }
    public string? BookName { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public List<string>? AuthorsName { get; set; }
    
    /// <summary>
    /// Compare current obejct data to parameter object
    /// </summary>
    /// <param name="obj">The BookResponse obj to compare</param>
    /// <returns>True or False, indicating weather all book details are equal with the parameter</returns>
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


// For converting from Book obj to BookResponse
public static class BookToBookResponseExtensions
{
    /// <summary>
    /// Convert Book Obj to a BookResponse Obj
    /// </summary>
    /// <param name="book">The Book for converting</param>
    /// <returns>Converted BookResponse Obj</returns>
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