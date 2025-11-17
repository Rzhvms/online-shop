using System.ComponentModel.DataAnnotations;

namespace Domain.Provider;

/// <summary>
/// Поставщик товара
/// </summary>
public record ProviderModel
{
    /// <summary>
    /// Идентификатор поставщика
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Название поставщика
    /// </summary>
    [MaxLength(100)]
    [Required]
    public required string Name { get; init; }
    
    /// <summary>
    /// Номер телефона поставщика
    /// </summary>
    [MaxLength(20)]
    public string? Phone { get; init; }
    
    /// <summary>
    /// Электронная почта поставщика
    /// </summary>
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { get; init; }
    
    /// <summary>
    /// Адрес поставщика
    /// </summary>
    public string? Address { get; init; }
}