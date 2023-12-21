

using Market.Business.Abstract;
using Market.Data;
using Market.Data.Abstract;
using Market.Entity.Concrete.DTO;
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



        public Data.GetProductResponse GetProduct(Data.GetProductRequest request)
        {
            var response = new Data.GetProductResponse();
            try
            {

                var products = _productRepository.GetList(/*p => p.Id == request.UserId*/);
                //foreach (var product in products)
                //{
                //var productModules = _productRepository.GetList();
                List<ProductModal> productModels = new List<ProductModal>();
                foreach (var product in products)
                {

                    var model = new ProductModal();
                    model.Id = product.Id;
                    model.CategoryId = product.CategoryId;
                    model.Name = product.Name;
                    model.UnitPrice = product.UnitPrice;
                    model.Stock = product.Stok;
                    model.Detail = product.Detail;
                    model.InDate = product.InDate;
                    model.OutDate = product.OutDate;
                    model.ExpirationDate = product.ExpirationDate;

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
