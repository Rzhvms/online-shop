using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;

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
    [JsonPropertyName("email")]
    public required string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    [JsonPropertyName("password")]
    public required string Password { get; set; }
    
    /// <summary>
    /// Права
    /// </summary>
    [JsonPropertyName("claims")]
    public IList<Claim> Claims { get; set; }
}