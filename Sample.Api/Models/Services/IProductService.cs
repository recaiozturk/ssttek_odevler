namespace Sample.Api.Models.Services
{
    public interface IProductService
    {
        ServiceResult<List<ProductDto>> GetProducts();
        ServiceResult<ProductDto> GetProduct(int id);
        ServiceResult UpdateProduct(int Id, UpdateProductRequest request);
    }
}
