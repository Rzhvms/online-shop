using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Application.UseCases.Auth.CreateUser.Request;

/// <summary>
/// Входная модель создания пользователя
/// </summary>
public record CreateUserRequest
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    [EmailAddress]
    [MaxLength(50)]
    [Required]
    public required string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    public required string Password { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    [MaxLength(50)]
    [Required]
    public required string Name { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    [MaxLength(50)]
    [Required]
    public required string LastName { get; set; }
    
    /// <summary>
    /// Права
    /// </summary>
    public IList<Claim> Claims { get; set; }
}