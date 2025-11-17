using System.ComponentModel.DataAnnotations;

namespace Domain.Order;

/// <summary>
/// Товары в заказе
/// </summary>
public record OrderProductModel
{
    /// <summary>
    /// Идентификатор товара в корзине
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid OrderId { get; init; }
    
    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public Guid ProductId { get; init; }
    
    /// <summary>
    /// Количество товаров в заказе
    /// </summary>
    [Required]
    [Range(0, int.MaxValue)]
    public required int Quantity { get; init; }
}