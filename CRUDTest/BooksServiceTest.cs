using Contracts;
using Contracts.DTOs;
using Services;

namespace CRUDTest;

public class BooksServiceTest
{
    private readonly IBooksService _booksService;

    public BooksServiceTest()
    {
        _booksService = new BooksService();
    }
    
    #region AddBook

    // When BookAddRequest is null, it should throw ArgumentNullException
    [Fact]
    public void AddBook_NullBook()
    {
        BookAddRequest? req = null;

        Assert.Throws<ArgumentNullException>(() =>
            _booksService.AddBook(req)
        );
    }
    
    // When BookName is null, it should throw ArgumentException
    [Fact]
    public void AddBook_NullBookName()
    {
        BookAddRequest? req = new BookAddRequest(){BookName = null};
        
        Assert.Throws<ArgumentException>(
            () =>
            _booksService.AddBook(req)
            );
    }
    
    // When BookName is duplicate, it should throw ArgumentException
    [Fact]
    public void AddBook_DuplicateBookName()
    {
        BookAddRequest req1 = new BookAddRequest(){BookName = "The Little Prince"};
        BookAddRequest req2 = new BookAddRequest(){BookName = "The Little Prince"};

        Assert.Throws<ArgumentException>(() =>
        {
            _booksService.AddBook(req1);
            _booksService.AddBook(req2);
        });

    }
    
    // When supplying propper BookName, it should add the Book to 
    [Fact]
    public void AddBook_ValidBook()
    {
        BookAddRequest req = new BookAddRequest(){BookName = "The Little Prince"};
        
        BookResponse response = _booksService.AddBook(req);
        
        Assert.True(response.BookId != Guid.Empty);
    }
    #endregion
    
}