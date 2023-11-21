using Microsoft.AspNetCore.Mvc;
using Market.Entity.Concrete.DTO;
using Market.Business.Abstract;
using System.Net.Http;
using Swashbuckle.AspNetCore.Annotations;
using Market.Business.Concrete;


namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private readonly IProductService _productService;

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(ILogger<ProductController> logger, IProductService productService, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _productService = productService?? throw new ArgumentNullException(nameof(productService));
            _httpClientFactory = httpClientFactory;
        }




        [SwaggerOperation(Summary = " listeleme ", Description = ".")]

        [HttpGet]
        [Route("GetProduct")]
        public GetProductResponse GetProduct([FromQuery] GetProductRequest request)


        {

            return _productService.GetProduct(request);

        }



    }
}
