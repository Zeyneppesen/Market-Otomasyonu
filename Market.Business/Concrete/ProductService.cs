using Market.Business.Abstract;
using Market.Business.Abstract;
using Market.Data.Abstract;
using Market.Data.Concrete.Ef;
using Market.Entity.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Concrete
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            var response = new GetProductResponse();
            try
            {
                var products = _productRepository.GetList(p => p.Id == request.UserId);
                foreach (var product in products)
                {
                    var productModules = _productRepository.GetList();
                    List<ProductModel> productModuless = new List<ProductModel>();
                    foreach (var productModule in productModules)
                    {

                        var model = new ProductModel();
                        model.Id = productModule.Id;
                        model.Name = productModule.Name;
                        productModuless.Add(model);
                    }
                    response.Products = productModuless;
                }
            
            
                response.Code = "200";
                response.Message = "Veriler getirildi.";
                return response;
            }
            catch (Exception e)
            {

                response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
                response.Code = "400";
                return response;
            }
        }
    }
}
