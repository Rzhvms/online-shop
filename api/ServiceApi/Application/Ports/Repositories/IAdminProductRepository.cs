using Domain.Product;

namespace Application.Ports.Repositories;

/// <summary>
/// Репозиторий по управлению продуктами
/// </summary>
public interface IAdminProductRepository
{
    /// <summary>
    /// Создать продукт
    /// </summary>
    Task CreateProductAsync(ProductModel product);

    /// <summary>
    /// Получить продукт
    /// </summary>
    Task<ProductModel> GetProductAsync(Guid id);

    /// <summary>
    /// Получить список продуктов
    /// </summary>
    Task<IEnumerable<ProductModel>> GetProductListAsync(string? search, Guid? providerId, int? skip, int? take);

    /// <summary>
    /// Изменить продукт
    /// </summary>
    Task UpdateProductAsync(ProductModel product);

    /// <summary>
    /// Удалить продукт
    /// </summary>
    Task DeleteProductAsync(Guid id);
    
    /// <summary>
    /// Проверить, есть ли продукт
    /// </summary>
    Task<bool> ExistsAsync(Guid id);
}