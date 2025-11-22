// using Application.Ports.Repositories;
// using Application.UseCases.AdminProduct.Dto.Request;
// using Application.UseCases.AdminProduct.Dto.Response;
//
// namespace Application.UseCases.AdminProduct;
//
// /// <inheritdoc />
// internal class AdminProductUseCase : IAdminProductUseCase
// {
//     private readonly IAdminProductRepository _repository;
//     
//     public AdminProductUseCase(IAdminProductRepository repository)
//     {
//         _repository = repository;
//     }
//     
//     /// <inheritdoc />
//     public async Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
//     {
//         
//     }
//
//     /// <inheritdoc />
//     public async Task<GetProductResponse> GetProductAsync(Guid id)
//     {
//         
//     }
//     
//     /// <inheritdoc />
//     public async Task<GetProductListResponse> GetProductListAsync(GetProductListRequest request)
//     {
//         
//     }
//
//     /// <inheritdoc />
//     public async Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
//     {
//         
//     }
//
//     /// <inheritdoc />
//     public async Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request)
//     {
//         
//     }
// }