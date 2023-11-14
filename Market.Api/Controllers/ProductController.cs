using Market.Business.Abstract;
using Market.Data.Abstract;
using Market.Business.Concrete;
using Market.Data.Concrete.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Market.Entity.Concrete.DTO;
using Market.Entity.Concrete.Model;
using System.Security.Claims;
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
