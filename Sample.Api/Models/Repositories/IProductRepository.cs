using Sample.Api.Models.Repositories.Entities;

namespace Sample.Api.Models.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product? GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
