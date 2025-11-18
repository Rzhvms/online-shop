using Application.UseCases.AdminProduct.Dto.Request;
using Application.UseCases.AdminProduct.Dto.Response;

namespace Application.UseCases.AdminProduct;

/// <summary>
/// UseCase по управлению продуктами на админ панели
/// </summary>
public interface IAdminProductUseCase
{
    /// <summary>
    /// Создать продукт
    /// </summary>
    Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request);

    /// <summary>
    /// Получить продукт
    /// </summary>
    Task<GetProductResponse> GetProductAsync(Guid id);

    /// <summary>
    /// Получить список продуктов
    /// </summary>
    Task<GetProductListResponse> GetProductListAsync(GetProductListRequest request);

    /// <summary>
    /// Изменить продукт
    /// </summary>
    Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request);

    /// <summary>
    /// Удалить продукт
    /// </summary>
    Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request);
}