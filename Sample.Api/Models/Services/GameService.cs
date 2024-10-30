using AutoMapper;
using Sample.Api.Models.Repositories;
using System.Net;

namespace Sample.Api.Models.Services
{
    public class GameService(IProductRepository productRepository,IMapper mapper)
    {
        public ServiceResult<List<ProductDto>> GetFavoriteGames()
        {
            var products = productRepository.GetProducts();

            var productsAsDto = mapper.Map<List<ProductDto>>(products);

            return ServiceResult<List<ProductDto>>.Success(productsAsDto, HttpStatusCode.OK);
        }
    }
}
