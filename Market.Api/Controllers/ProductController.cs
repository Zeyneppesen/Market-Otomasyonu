using Microsoft.AspNetCore.Mvc;
using Market.Entity.Concrete.DTO;
using Market.Business.Abstract;
using System.Net.Http;
using Swashbuckle.AspNetCore.Annotations;


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
            _productService = productService;
            _httpClientFactory = httpClientFactory;
        }

        //public ProductController(IProductService productService)
        //{
            
        //    _productService = productService;
        //}

        [SwaggerOperation(Summary = "Tarla Modülü listeleme ", Description = "<h2> Tarla Id </h2> Tarla id'si bilgisi girilerek modül getirme.")]

        [HttpGet]
        [Route("GetProduct")]
        public GetProductResponse GetProduct([FromQuery] GetProductRequest request)


        {

            return _productService.GetProduct(request);

        }



    }
}
