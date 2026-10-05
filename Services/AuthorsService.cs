using Contracts;
using Contracts.DTOs;
using Entities;

namespace Services;

public class AuthorsService:IAuthorsService
{
    // In memory collection
    private readonly List<Author> _authors;
    public AuthorsService()
    {
        _authors = new List<Author>();
    }
    public AuthorResponse AddAuthor(AuthorAddRequest? request)
    {
        // Validation for null request
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        // Validation for null AuthorName
        if (request.AuthorName == null)
            throw new ArgumentException(nameof(request.AuthorName));
        // Validation for duplicate AuthorName
        if(_authors.Any(temp => temp.AuthorName == request.AuthorName))
            throw new ArgumentException("This author is already exists");

        Author authorToAdd = request.ToAuthor();
        
        authorToAdd.AuthorId = Guid.NewGuid();
        
        _authors.Add(authorToAdd);
        
        return authorToAdd.ToAuthorResponse();
        
    }

    public List<AuthorResponse> GetAllAuthors()
    {
        return _authors.Select(temp  => temp.ToAuthorResponse()).ToList();
    }

    public AuthorResponse? GetAuthorById(Guid? id)
    {
        if(id == null)
            return  null;
        
        Author? desiredAuthor = _authors.FirstOrDefault(temp => temp.AuthorId == id);
        
        if(desiredAuthor == null)
            return  null;
        
        return desiredAuthor.ToAuthorResponse();
    }
}