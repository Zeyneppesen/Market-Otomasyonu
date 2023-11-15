using Microsoft.AspNetCore.Mvc;
using Market.Entity.Concrete.DTO;
using Market.Business.Abstract;
using Swashbuckle.AspNetCore.Annotations;


namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [SwaggerOperation(Summary = "Tarla Modülü listeleme ", Description = "<h2> Tarla Id </h2> Tarla id'si bilgisi girilerek modül getirme.")]

        [HttpGet]
        [Route("GetProduct")]
        public GetProductResponse GetProduct(GetProductRequest request)
        {

            return _productService.GetProduct(request);

        }
    }
}
