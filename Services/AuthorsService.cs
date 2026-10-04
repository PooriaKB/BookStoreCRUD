using Contracts;
using Contracts.DTOs;

namespace Services;

public class AuthorsService:IAuthorsService
{
    public AuthorResponse AddAuthor(AuthorAddRequest? request)
    {
        throw new NotImplementedException();
    }

    public List<AuthorResponse> GetAllAuthors()
    {
        throw new NotImplementedException();
    }

    public AuthorResponse? GetAuthorById(Guid? id)
    {
        throw new NotImplementedException();
    }
}