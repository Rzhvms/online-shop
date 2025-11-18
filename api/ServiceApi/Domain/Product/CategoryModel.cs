using System.ComponentModel.DataAnnotations;

namespace Domain.Product;

/// <summary>
/// Модель категорий товаров
/// </summary>
public record CategoryModel
{
    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Название категории
    /// </summary>
    [MaxLength(100)]
    public string? Name { get; init; }
    
    /// <summary>
    /// Идентификатор родительской категории для дерева категорий
    /// </summary>
    public Guid? ParentId { get; init; }
}