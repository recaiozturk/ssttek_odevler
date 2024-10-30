using AutoMapper;
using Sample.Api.Models;
using Sample.Api.Models.Repositories.Entities;

namespace Sample.Api.Mappers
{
    public class AppMaper:Profile
    {
        public AppMaper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
        }
    }
}
