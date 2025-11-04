using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Auth.Login.Request;

/// <summary>
/// Входная модель для авторизации пользователя
/// </summary>
public record LoginRequest
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    [Required]
    [MaxLength(50)]
    public required string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    public required string Password { get; set; }
}