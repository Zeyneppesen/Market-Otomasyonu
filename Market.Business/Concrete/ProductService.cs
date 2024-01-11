using FluentAssertions;
using Market.Business.Abstract;
using Market.Data;
using Market.Data.Abstract;
using Market.Entity;
using Market.Entity.Concrete.Model;
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
        public GetProductResponse GetListByCategory(GetProductRequest request, long categoryId)
        {
            var response = new GetProductResponse();
            try
            {
                var products = _productRepository.GetList(p => p.CategoryId == categoryId); //verilen categori Idsine göre getirir.
                //var products = _productRepository.GetList(); hepsini getirir
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

                response.ProductModels = productsModels;
                _logger.LogInformation("Veriler getirildi.");

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

        public GetProductResponse GetProductExp(GetProductRequest request)
        {
            var response = new GetProductResponse();
            try
            {
              //  var products = _productRepository.GetList(p => p.Name == productName); // ismi yazılan ürün verilerini getirir.
                var products = _productRepository.GetList();// hepsini getirir
                List<ModelProduct> productsModels = new List<ModelProduct>();
                
                foreach (var product in products)
                {
                   
                    var model = new ModelProduct();
                    model.Id = product.Id;
                    model.CategoryId = product.CategoryId;
                    model.Name = product.Name;
                    //model.UnitPrice = product.UnitPrice;
                    //model.Stock = product.Stok;
                    //model.Detail = product.Detail;
                    //model.Status = product.Status;
                    //model.CreatedDate = product.CreatedDate;
                    //model.ModifiedDate = product.ModifiedDate;
                    //model.DeletedDate = product.DeletedDate;
                    model.ExpirationDate = product.ExpirationDate.HasValue? product.ExpirationDate.Value : DateTime.MinValue;
                    //if (product.ExpirationDate.HasValue && product.ExpirationDate > DateTime.Now)
                    //{
                    //    // Son kullanma tarihi geçmediyse, model'e ekle
                    //    model.ExpirationDate = product.ExpirationDate.Value;
                    //    productsModels.Add(model);
                    //}
                    var kalanGun = (int)(product.ExpirationDate.Value - DateTime.Now).TotalDays;
                    model.KalanGun = kalanGun;
                    productsModels.Add(model);
                }

                response.ProductModels = productsModels;
                _logger.LogInformation("Veriler getirildi.");

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
