using Microsoft.AspNetCore.Mvc;
using Market.Entity.Concrete.DTO;
using Market.Business.Abstract;
using System.Net.Http;
using Swashbuckle.AspNetCore.Annotations;
using Market.Business.Concrete;
using Microsoft.EntityFrameworkCore;
using Market.Entity.Concrete.Model;


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
            return _productService.GetProduct(request);
        }

    }
}
