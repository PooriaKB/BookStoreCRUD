using Contracts.DTOs;

namespace Contracts;

public interface IBooksService
{
    /// <summary>
    /// Adds a Book obj to the list of Books
    /// </summary>
    /// <param name="request">Book obj to add</param>
    /// <returns>Returns the added book obj with its ID</returns>
    public BookResponse AddBook(BookAddRequest? request);
}