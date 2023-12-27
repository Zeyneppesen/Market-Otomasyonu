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

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
             _logger = logger;
        }


        public GetProductResponse GetList(GetProductRequest request)
        {
            var response = new GetProductResponse();
            try
            {

                var products = _productRepository.GetList(/*p => p.Id == request.UserId*/);
                //foreach (var product in products)
                //{
                //var productModules = _productRepository.GetList();
                List<ModelProduct> productsModels = new List<ModelProduct>();
                foreach (var product in products)
                {

                    var model = new ModelProduct();
                    model.Id = product.Id;
                    model.CategoryId = product.CategoryId;
                    model.Name = product.Name;
                    model.UnitPrice = product.UnitPrice;
                    model.Stock = product.Stok;
                    model.Detail = product.Detail;
                    model.Status = product.Status;
                    model.CreatedDate = product.CreatedDate;
                    model.ModifiedDate = product.ModifiedDate;
                    model.DeletedDate = product.DeletedDate;


                    productsModels.Add(model);
                }
                //}
                response.ProductModels = productsModels;

                _logger.LogInformation("Veriler getirildi.");
                string DosyaYolu = Environment.CurrentDirectory + @"\ERROR\Error.txt";
                if (!File.Exists(DosyaYolu))
                {
                    File.Create(DosyaYolu);
                }

                response.Code = "200";
                response.Message = "Veriler getirildi";
                return response;
            }
            catch (Exception e)
            {


                _logger.LogError(e, "Bir hata ile karşılaştı: {ErrorMessage}" + e.Message);
                 response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
                response.Code = "400";
                return response;
            }
        }
    }

      
}
