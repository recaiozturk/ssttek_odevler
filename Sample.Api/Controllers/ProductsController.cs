using Microsoft.AspNetCore.Mvc;
using Sample.Api.Models;
using Sample.Api.Models.Services;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        //[FromServices] --> senaryo : id ye göre ürün getir
        [HttpGet("from-services/{id}")]
        public IActionResult GetProductFromService([FromServices] IProductService productFromService, int id)
        {
            var result = productFromService.GetProduct(id);
            return new ObjectResult(result) { StatusCode = (int)result.Status };
        }

        //[FromKeyedService] --> senaryo : favori oyunlarımı getir
        [HttpGet("keyed-service")]
        public IActionResult GetProductFromKeyedService([FromKeyedServices("GameService")] GameService gameService)
        {
            var result = gameService.GetFavoriteGames();
            return new ObjectResult(result){StatusCode = (int)result.Status};
        }

        //[FromHeader] ve [FromBody]  --> senaryo : Ürün güncelleme
        [HttpPut("from-header-and-body")]
        public IActionResult UpdateProductFromHeader([FromHeader(Name = "Product-Id")] int productId,[FromBody] UpdateProductRequest updatedProduct)
        {
            var result = productService.UpdateProduct(productId, updatedProduct);
            return new ObjectResult(result) { StatusCode = (int)result.Status };

        }

        //[FromQuery] --> senaryo :product mevcut mu
        [HttpGet("from-query")]
        public IActionResult IsProductAvailable([FromQuery] string productName)
        {
            var result = productService.IsProductAvailable(productName);
            return new ObjectResult(result) { StatusCode = (int)result.Status };
        }

        //[FromRoute] --> senaryo :product silinmesi
        [HttpDelete("from-route")]
        public IActionResult DeleteProduct([FromQuery] string productId)
        {
            var result = productService.DeleteProduct(int.Parse(productId));
            return new ObjectResult(result) { StatusCode = (int)result.Status };
        }

    }
}
