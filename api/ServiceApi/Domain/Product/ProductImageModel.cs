namespace Domain.Product;

/// <summary>
/// Изображение продукта
/// </summary>
public record ProductImageModel
{
    /// <summary>
    /// Идентификатор изображения
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public Guid ProductId { get; init; }
    
    /// <summary>
    /// Ссыкла на изображение
    /// </summary>
    public string? Url { get; init; }
    
    /// <summary>
    /// Порядок сортировки изображений
    /// </summary>
    public int? SortOrder { get; init; }
}