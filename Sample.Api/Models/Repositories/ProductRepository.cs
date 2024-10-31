using Sample.Api.Models.Repositories.Entities;

namespace Sample.Api.Models.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly List<Product> Products;

        public ProductRepository()
        {
            Products = new List<Product>
            {
                new Product {Id = 1,Name = "Elden Ring",Price = 500},
                new Product {Id = 2,Name = "Bloodborne",Price = 500},
                new Product {Id = 3,Name = "Sekiro",Price = 500},
                new Product {Id = 4,Name = "Dark Souls 3",Price = 500},
                new Product {Id = 5,Name = "Mass Effect : Legendary Edition",Price = 500},

            };
        }


        public List<Product> GetProducts()
        {
            return Products;
        }

        public Product? GetProduct(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }


        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = Products.FirstOrDefault(x => x.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
            }
        }

        public void DeleteProduct(int id)
        {
            var product =GetProduct(id);
            var productToDelete = Products.FirstOrDefault(x => x.Id == id);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
        }

        public bool IsProductAvailable(string productName)
        {
            return Products.Any(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
