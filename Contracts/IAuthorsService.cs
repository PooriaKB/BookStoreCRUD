using Contracts.DTOs;

namespace Contracts;

public interface IAuthorsService
{
    /// <summary>
    /// Adds an Author to list of Authors 
    /// </summary>
    /// <param name="request">AuthorAddRequest obj to add</param>
    /// <returns>Returns the added author obj as an AuthorResponse</returns>
    public AuthorResponse AddAuthor(AuthorAddRequest? request);
    
    /// <summary>
    /// Return All authors from memory/Db
    /// </summary>
    /// <returns>All authors from memory/Db as a List of AuthorResponse</returns>
    public List<AuthorResponse> GetAllAuthors();
    
    /// <summary>
    /// Returns an Author by its ID
    /// </summary>
    /// <param name="id">The id of the wanted author</param>
    /// <returns>The specific author that has the given id</returns>
    public AuthorResponse? GetAuthorById(Guid? id);
}