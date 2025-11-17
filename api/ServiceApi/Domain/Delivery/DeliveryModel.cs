using System.ComponentModel.DataAnnotations;

namespace Domain.Delivery;

/// <summary>
/// Модель доставки
/// </summary>
public record DeliveryModel
{
    /// <summary>
    /// Айди доставки
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Дата доставки
    /// </summary>
    [Required]
    public required DateTime Date { get; init; }
    
    /// <summary>
    /// Адрес доставки
    /// </summary>
    [Required]
    public required string Address { get; init; }
    
    /// <summary>
    /// Цена доставки
    /// </summary>
    [Required]
    [Range(0, double.MaxValue)]
    public required decimal Price { get; init; }
}