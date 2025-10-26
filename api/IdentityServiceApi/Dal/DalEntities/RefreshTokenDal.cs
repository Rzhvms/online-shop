using System.ComponentModel.DataAnnotations;

namespace Dal.DalEntities;

/// <summary>
/// Dal сущность refresh токена.
/// Содержит связь с пользователем и метаданные сессии.
/// </summary>
public record RefreshTokenDal()
{
    /// <summary>
    /// Id пользователя, которому принадлежит токен
    /// </summary>
    [Required]
    public required Guid UserId { get; set; }
    
    /// <summary>
    /// Refresh токен
    /// </summary>
    [Required]
    public required string RefreshToken { get; set; }
    
    /// <summary>
    /// Дата и время истечения токена
    /// </summary>
    [Required]
    public required DateTime ExpireAt { get; set; }
    
    /// <summary>
    /// Отозван ли токен
    /// </summary>
    [Required]
    public required bool IsRevoked { get; set; } = false;
    
    /// <summary>
    /// Дата и время создания токена
    /// </summary>
    [Required]
    public required DateTime CreatedAt { get; set; }
}