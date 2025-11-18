using Application.UseCases.AdminProduct;
using Application.UseCases.AdminProduct.Dto.Request;
using Application.UseCases.AdminProduct.Dto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AdminProductController;

/// <summary>
/// Контроллер по управлению продуктами на админ панели
/// </summary>
[ApiController]
[Route("api/admin-product")]
[Authorize]
public class AdminProductController : ControllerBase
{
    private readonly IAdminProductUseCase _adminProductUseCase;
    
    public AdminProductController(IAdminProductUseCase adminProductUseCase)
    {
        _adminProductUseCase = adminProductUseCase;
    }
    
    /// <summary>
    /// Создать продукт
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
    {
        return await _adminProductUseCase.CreateProductAsync(request);
    }

    /// <summary>
    /// Получить продукт
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<GetProductResponse> GetProductAsync([FromRoute] Guid id)
    {
        return await _adminProductUseCase.GetProductAsync(id);
    }
    
    /// <summary>
    /// Получить список продуктов
    /// </summary>
    [HttpGet("list")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<GetProductListResponse> GetProductListAsync(GetProductListRequest request)
    {
        return await _adminProductUseCase.GetProductListAsync(request);
    }

    /// <summary>
    /// Изменить продукт
    /// </summary>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
    {
        return await _adminProductUseCase.UpdateProductAsync(request);
    }

    /// <summary>
    /// Удалить продукт
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request)
    {
        return await _adminProductUseCase.DeleteProductAsync(request);
    }
}