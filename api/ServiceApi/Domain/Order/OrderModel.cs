using System.ComponentModel.DataAnnotations;

namespace Domain.Order;

/// <summary>
/// Модель заказа
/// </summary>
public record OrderModel
{
    /// <summary>
    /// Айди заказа
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор клиента покупателя (userId)
    /// </summary>
    [Required]
    public required Guid CustomerId { get; init; }
    
    /// <summary>
    /// Состояние заказа
    /// </summary>
    public OrderStateEnum State { get; init; }
    
    /// <summary>
    /// Идентификатор доставки
    /// </summary>
    public Guid? DeliveryId { get; init; }
    
    /// <summary>
    /// Сумма заказа
    /// </summary>
    [Required]
    [Range(0, double.MaxValue)]
    public required decimal TotalSum { get; init; }
    
    /// <summary>
    /// Дата заказа
    /// </summary>
    [Required]
    public required DateTime OrderDate { get; init; }
}