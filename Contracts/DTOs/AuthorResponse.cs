using Entities;

namespace Contracts.DTOs;
/// <summary>
/// DTO Class that is used as return type for most of AuthorsService
/// </summary>
public class AuthorResponse
{
  public Guid AuthorId { get; set; }
  public string? AuthorName { get; set; }

  /// <summary>
  /// Compare current obj data to param obj
  /// </summary>
  /// <param name="obj">The AuthorResponse obj to compare</param>
  /// <returns>True or False, indicating weather all author details are equal with the parameter</returns>
  public override bool Equals(object? obj)
  {
      if(obj == null || obj.GetType() != typeof(AuthorResponse))
          return false;
      
      AuthorResponse authorResponse = (AuthorResponse)obj;
      
      return AuthorId == authorResponse.AuthorId && AuthorName == authorResponse.AuthorName;
  }

  public override int GetHashCode() => base.GetHashCode();
}
/// <summary>
/// For converting Author obj to AuthorResponse obj
/// </summary>
public static class AuthorToAuthorResponseExtensions
{
    /// <summary>
    /// Convert Author obj to a AuthorResponse obj
    /// </summary>
    /// <param name="author">The Author obj to convert</param>
    /// <returns>Converted AuthorResponse obj</returns>
    public static AuthorResponse ToAuthorResponse(this Author author) => new AuthorResponse()
    {
        AuthorId = author.AuthorId,
        AuthorName = author.AuthorName
    };
}