namespace Domain.Product;

/// <summary>
/// Таблица связка продуктов и категорий
/// </summary>
public record ProductCategoryModel
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public Guid ProductId { get; init; }
    
    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public Guid CategoryId { get; init; }
}