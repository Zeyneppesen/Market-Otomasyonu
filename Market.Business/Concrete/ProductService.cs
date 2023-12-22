

using Market.Business.Abstract;
using Market.Data;
using Market.Data.Abstract;
using Market.Entity;
using Market.Entity.DTO;
using Microsoft.Extensions.Logging;

namespace Market.Business.Concrete
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository,ILogger< ProductService >logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }



        public GetProductResponse GetProduct(GetProductRequest request)
        {
            var response = new GetProductResponse();
            try
            {

                var products = _productRepository.GetList(/*p => p.Id == request.UserId*/);
                //foreach (var product in products)
                //{
                //var productModules = _productRepository.GetList();
                List<ModelProduct> productModels = new List<ModelProduct>();
                foreach (var product in products)
                {

                    var model = new ModelProduct();
                    model.Id = product.Id;
                    model.CategoryId = product.CategoryId;
                    model.Name = product.Name;
                    model.UnitPrice = product.UnitPrice;
                    model.Stock = product.Stok;
                    model.Detail = product.Detail;


                    productModels.Add(model);
                }
                //}

                _logger.LogInformation("Veriler getirildi.");
                string DosyaYolu = Environment.CurrentDirectory + @"\ERROR\Error.txt";
                if (!File.Exists(DosyaYolu))
                {
                    File.Create(DosyaYolu);
                }

                response.Products = productModels;
                return response;
            }
            catch (Exception e)
            {

                _logger.LogError(e, "Bir hata ile karşılaştı: {ErrorMessage" + e.Message);
                return response;
            }
        }
    }
}
