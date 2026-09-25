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
    
    /// <summary>
    /// Returns All Books from the memory/DB
    /// </summary>
    /// <returns> All Books from the memory/DB as a list of BookResponse</returns>
    public List<BookResponse> GetAllBooks();

    /// <summary>
    /// Returns a Book by its ID
    /// </summary>
    /// <param name="id">The ID of the wanted book</param>
    /// <returns>The specific book that has the given id</returns>
    public BookResponse? GetBookById(Guid? id);

    // TODO: Defining DeleteBook & UpdateBook


}