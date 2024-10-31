using AutoMapper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Sample.Api.Models.Repositories;
using Sample.Api.Models.Repositories.Entities;
using System.Net;

namespace Sample.Api.Models.Services
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) :IProductService
    {
        public ServiceResult<List<ProductDto>> GetProducts()
        {
            var products = productRepository.GetProducts();
            var productsAsDto = mapper.Map<List<ProductDto>>(products);
            return ServiceResult<List<ProductDto>>.Success(productsAsDto, HttpStatusCode.OK);
        }

        public ServiceResult<ProductDto> GetProduct(int id)
        {
            var product = productRepository.GetProduct(id);

            if (product is null)
                return ServiceResult<ProductDto>.Fail("Product not found", HttpStatusCode.NotFound);
            
            var productAsDto = mapper.Map<ProductDto>(product);

            return ServiceResult<ProductDto>.Success(productAsDto, HttpStatusCode.OK);
        }

        public ServiceResult UpdateProduct(int Id,UpdateProductRequest request)
        {
            var product = productRepository.GetProduct(Id);
            var productToUpdate = mapper.Map(request, product);
            productRepository.UpdateProduct(productToUpdate);

            return ServiceResult.Success(HttpStatusCode.OK);
        }

        public ServiceResult DeleteProduct(int Id)
        {
            productRepository.DeleteProduct(Id);
            return ServiceResult.Success(HttpStatusCode.OK);
        }

        public ServiceResult<bool> IsProductAvailable(string productName)
        {
            var isAviliable=productRepository.IsProductAvailable(productName);
            if(!isAviliable)
                return ServiceResult<bool>.Fail("Product no aviliable", HttpStatusCode.NotFound);

            return ServiceResult<bool>.Success(true,HttpStatusCode.OK);
        }
    }
}
