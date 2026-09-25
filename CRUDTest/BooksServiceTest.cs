using Contracts;
using Contracts.DTOs;
using Services;
using FluentAssertions;
using AutoFixture;

namespace CRUDTest;

public class BooksServiceTest
{
    private readonly IBooksService _booksService;
    private readonly IFixture _fixture;

    public BooksServiceTest()
    {
        _fixture = new Fixture();
        _booksService = new BooksService();
    }
    
    #region AddBook

    // When BookAddRequest is null, it should throw ArgumentNullException
    [Fact]
    public void AddBook_NullBook()
    {
        // Arrange
        BookAddRequest? req = null;
        
        // Act
        Func<BookResponse> action = () => _booksService.AddBook(req);
        
        // Assert
        action.Should().Throw<ArgumentNullException>();
    }
    
    // When BookName is null, it should throw ArgumentException
    [Fact]
    public void AddBook_NullBookName()
    {
        // Arrange
        BookAddRequest? req = _fixture.Build<BookAddRequest>()
            .With(tmp => tmp.BookName, null as string).Create();
        // Act
        Func<BookResponse> action = () => _booksService.AddBook(req);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    // When BookName is duplicate, it should throw ArgumentException
    [Fact]
    public void AddBook_DuplicateBookName()
    {
        // Arrange
        BookAddRequest req1 = _fixture.Build<BookAddRequest>()
            .With(tmp => tmp.BookName, "The Little Prince").Create();
        BookAddRequest req2 = _fixture.Build<BookAddRequest>()
            .With(tmp => tmp.BookName, req1.BookName).Create();

        // Act
         var action = () =>
        {
            _booksService.AddBook(req1);
            _booksService.AddBook(req2);
        };
        
        action.Should().Throw<ArgumentException>();

    }
    
    // When supplying propper Book detail, it should add the Book to 
    [Fact]
    public void AddBook_ValidBook()
    {
        // Arrange
        BookAddRequest req = _fixture.Create<BookAddRequest>();
        
        // Act
        BookResponse response = _booksService.AddBook(req);
        List<BookResponse> actualBookResponseList = _booksService.GetAllBooks();
        
        // Assert
        response.BookId.Should().NotBe(Guid.Empty);
        actualBookResponseList.Should().Contain(response);
    }
    #endregion
    
    #region GetAllBooks
    
    // Before adding any Books the list of books should be empty by default
    [Fact]
    public void GetAllBooks_EmptyList()
    {
        // Act
        List<BookResponse> actualBookResponseList = _booksService.GetAllBooks();
        
        // Assert
        actualBookResponseList.Should().BeEmpty();
        
    }
    
    // When the list contains books, it should return all of them
    [Fact]
    public void GetAllBooks_ValidList()
    {
        // Arrange
        List<BookAddRequest> bookAddRequestList = _fixture.Create<List<BookAddRequest>>();

        List<BookResponse> bookResponseListFormAdd = new List<BookResponse>();
        foreach (BookAddRequest bookAddRequest in bookAddRequestList)
        {
            BookResponse addedBook = _booksService.AddBook(bookAddRequest);
            
            bookResponseListFormAdd.Add(addedBook);
        }
        
        // Act
        List<BookResponse> actualBookResponseList = _booksService.GetAllBooks();
        
        // Assert
        actualBookResponseList.Should().BeEquivalentTo(bookResponseListFormAdd);
        
    }
    
    #endregion
    
    #region GetBookById
    
    // If the given id is null the response should be null
    [Fact]
    public void GetBookById_NullBookId()
    {
        // Act
        BookResponse? responseFromGet = _booksService.GetBookById(null);
        
        // Assert
        responseFromGet.Should().BeNull();
    }
    
    // If the given id is a valid one, it should return the matching country details
    [Fact]
    public void GetBookById_ValidBookId()
    {
        // Arrange
        BookAddRequest req = _fixture.Create<BookAddRequest>();
        BookResponse responseFromAdd = _booksService.AddBook(req);
        
        // Act
        BookResponse? responseFromGet = _booksService.GetBookById(responseFromAdd.BookId);
        
        // Assert
        responseFromGet.Should().BeEquivalentTo(responseFromAdd);
    }
    
    #endregion
    // TODO: DeleteBook & UpdateBook tests
    
}