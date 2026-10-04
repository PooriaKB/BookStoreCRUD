using System.ComponentModel.DataAnnotations;
using Entities;

namespace Contracts.DTOs;
/// <summary>
/// DTO Class for adding a new Author
/// </summary>
public class AuthorAddRequest
{
    [Length(2,100)]
    [Required(ErrorMessage = "Author name can't be empty")]
    public string? AuthorName { get; set; }
    /// <summary>
    /// Convert current obj of the AuthorAddRequest to Author obj
    /// </summary>
    /// <returns>Author obj from convert</returns>
    public Author ToAuthor() => new Author
    {
        AuthorName = AuthorName
    };
}