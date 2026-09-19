using Contracts;
using Contracts.DTOs;
using Entities;

namespace Services;

public class BooksService : IBooksService
{
    // In Memory Collection
    private readonly List<Book> _books;

    public BooksService()
    {
        _books = new List<Book>();
    }
    
    public BookResponse AddBook(BookAddRequest? request)
    {
        // Validation: BookAddRequest param can't be null
        if (request == null)
            throw new ArgumentNullException(nameof(request));
        
        // Validation: BookName can't be null
        if (request.BookName == null)
        {
            throw new ArgumentException(nameof(request.BookName));
        }
        
        // Validation: BookName can't be duplicate
        if(_books.Count(temp => temp.BookName == request.BookName) > 0)
            throw new ArgumentException("This book already exists");

        Book addedBook = request.ToBook();

        addedBook.BookId = Guid.NewGuid();
        
        _books.Add(addedBook);
        
        return addedBook.ToBookResponse();


    }
}