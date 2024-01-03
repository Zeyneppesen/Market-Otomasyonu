using Market.Business.Abstract;
using Market.Entity;
using Microsoft.AspNetCore.Mvc;


namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;

        }
    

        [HttpGet]
        [Route("GetProduct")]
        public GetProductResponse GetProduct()
        {
            GetProductRequest request = new GetProductRequest();
            return _productService.GetList(request);
        }
        [HttpGet("Id si verilen kategoriyi listele")]
        public GetProductResponse GetProductByCategory(long categoryId)
        {
            GetProductRequest request = new GetProductRequest();
            return _productService.GetListByCategory(request, categoryId);
        }
        [HttpGet("Ürünün son kullanma tarihi")]
        public GetProductResponse GetProductExp(string productName)
        {
            GetProductRequest request = new GetProductRequest();
            return _productService.GetProductExp(request, productName);
        }


    }
}
