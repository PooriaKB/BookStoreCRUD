using AutoFixture;
using Contracts.DTOs;
using FluentAssertions;
using Services;

namespace CRUDTest;

public class AuthorsServiceTest
{
    private readonly AuthorsService _authorsService;
    private readonly Fixture _fixture;
    
    public AuthorsServiceTest()
    {
        _fixture = new Fixture();
        _authorsService = new AuthorsService();
    }
    #region AddAuthor
    // When AuthorAddRequest is null, should throw ArgumentNullException
    [Fact]
    public void AddAuthor_NullAuthor()
    {
        // Arrange
        AuthorAddRequest? request = null;
        // Act
        Func<AuthorResponse> action = () => _authorsService.AddAuthor(request);
        // Assert
        action.Should().Throw<ArgumentNullException>();
    }
    
    // When AuthorName is null, it should throw ArgumentException
    [Fact]
    public void AddAuthor_NullAuthorName()
    {
        // Arrange
       AuthorAddRequest? request = _fixture.Build<AuthorAddRequest>()
           .With(temp => temp.AuthorName, null as string).Create(); 
       // Act
       Func<AuthorResponse> action = () => _authorsService.AddAuthor(request);
       // Assert
       action.Should().Throw<ArgumentException>();
    }
    
    //  When AuthorName is duplicate, it should throw ArgumentException
    [Fact]
    public void AddAuthor_DuplicateAuthorName()
    {
        // Arrange
        AuthorAddRequest? request1 = _fixture.Build<AuthorAddRequest>()
            .With(temp => temp.AuthorName, "John").Create();
        AuthorAddRequest request2 = _fixture.Build<AuthorAddRequest>()
            .With(temp => temp.AuthorName, request1.AuthorName).Create();
        // Act
        var action = () =>
        {
            _authorsService.AddAuthor(request1);
            _authorsService.AddAuthor(request2);
        };
        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    // When supplying propper Book detail, it should add the Book
    [Fact]
    public void AddAuthor_ValidAuthor()
    {
        // Arrange
        AuthorAddRequest request = _fixture.Create<AuthorAddRequest>();
        // Act
        AuthorResponse responseFromAdd = _authorsService.AddAuthor(request);
        List<AuthorResponse>? authorsFromGet = _authorsService.GetAllAuthors();
        // Assert
        responseFromAdd.AuthorId.Should().NotBe(Guid.Empty);
        authorsFromGet.Should().Contain(responseFromAdd);
    }
    #endregion
    
    #region GetAllAuthors
    // Before adding any Authors the list of Authors should be empty by default
    [Fact]
    public void GetAllAuthors_EmptyList()
    {
        // Act
        List<AuthorResponse>? authorsFromGet = _authorsService.GetAllAuthors();
        // Assert
        authorsFromGet.Should().BeEmpty();
    }
    // When the list contains Authors, it should return all of them
    [Fact]
    public void GetAllAuthors_ValidList()
    {
        // Arrange
        List<AuthorAddRequest> authorAddRequestsList = _fixture.Create<List<AuthorAddRequest>>();
        List<AuthorResponse> authorsFromAdd = new List<AuthorResponse>();
        // Act
        foreach (AuthorAddRequest request in authorAddRequestsList )
            authorsFromAdd.Add(_authorsService.AddAuthor(request));
        
        List<AuthorResponse> authorsFromGet = _authorsService.GetAllAuthors();
        // Assert
        authorsFromGet.Should().BeEquivalentTo(authorsFromAdd);
        
    }
    #endregion
    
    #region GetAuthorById
    // If the given id is null, the response should be null
    [Fact]
    public void GetAuthorById_NullAuthorId()
    {
        // Act
        AuthorResponse? response = _authorsService.GetAuthorById(null);
        // Assert
        response.Should().BeNull();
    }
    // If the given id is an invalid one, it should return null
    [Fact]
    public void GetAuthorById_InvalidAuthorId()
    {
        // Act
        AuthorResponse? response = _authorsService.GetAuthorById(Guid.NewGuid());
        // Assert
        response.Should().BeNull();
    }
    // If the given id is a valid one, it should return the specific Author with that id
    [Fact]
    public void GetAuthorById_ValidAuthorId()
    {
        // Arrange
        AuthorAddRequest request = _fixture.Create<AuthorAddRequest>();
        AuthorResponse authorFromAdd = _authorsService.AddAuthor(request);
        // Act
        AuthorResponse? authorFromGet = _authorsService.GetAuthorById(authorFromAdd.AuthorId);
        // Assert
        authorFromGet.Should().BeEquivalentTo(authorFromAdd);
    }
    #endregion
    
    
}