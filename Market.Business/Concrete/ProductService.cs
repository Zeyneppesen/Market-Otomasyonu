using FluentAssertions;
using FluentValidation;
using Market.Business.Abstract;
using Market.Data;
using Market.Data.Abstract;
using Market.Entity;
using Market.Entity.Concrete.Model;
using Market.Entity.Concrete.Validators;
using Market.Entity.DTO;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

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

        
        public AddProductResponse AddProduct(AddProductRequest request)
        {
            var response = new AddProductResponse();
            var existingProduct = _productRepository.Get(p => p.Name == request.Name);

            try
            {

                if (existingProduct != null)
                {
                    existingProduct.Stok+= request.Quantity;
                    _productRepository.Update(existingProduct);
                    existingProduct.Quantity = request.Stok;
                    response.Code = "200";
                    response.Message = "Veri Güncellendi";
                    return response;

                }

                else
                {
                    

                    var validator = new AddProductValidator();
                    var validatorResult = validator.Validate(request);
                    var product = new Product();
                    product.Id = request.Id;
                    product.CategoryId = request.CategoryId;
                    product.Name = request.Name;
                    product.UnitPrice = request.UnitPrice;
                    product.Stok = request.Stok;
                    product.Detail = request.Detail;
                    product.Status = request.Status;
                    product.CreatedDate = request.CreateDate;
                    product.ModifiedDate = request.ModifiedDate;
                    product.DeletedDate = request.DeletedDate;
                    product.ExpirationDate = request.ExpirationDate;
                    _productRepository.Add(product);
                    response.Code = "200";
                    response.Message = "Veri Eklendi";
                    return response;
                }


            }
            catch (Exception e)
            {
                response.Message = e + " Hatası";
                response.Code = "400";
                return response;
            }
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
        public GetProductResponse GetCategory(GetProductRequest request, long categoryId)
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

   

        public GetProductResponse GetProductExp(GetProductRequest request, string productName)
        {
            {
                var response = new GetProductResponse();
                try
                {
                    var products = _productRepository.GetList(p => p.Name == productName); // ismi yazılan ürün verilerini getirir.
                                                                                           //var products = _productRepository.GetList();// hepsini getirir
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
                        model.ExpirationDate = product.ExpirationDate.HasValue ? product.ExpirationDate.Value : DateTime.MinValue;
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

        public SellProductResponse SellProduct(SellProductRequest request)
        {
            var response = new SellProductResponse();
            try
            {
                
                var product = _productRepository.Get(p => p.Id == request.Id);
                if(product!= null&&product.Stok>=request.Quantity)
                {
                    product.Stok-=request.Quantity;
                    _productRepository.Delete(product);
                    response.Code = "200";
                    response.Message = "Satıldı";
                    return response;
                }
                else
                {
                    response.Code = "400";
                    response.Message = "Ürün stokta yeterli değil veya ürün bulunamadı.";
                }


            }
            catch (Exception e)
            {
                response.Errors.Add("Bir hata ile karşılaştı."+$"{e.Message}");
                response.Code = "400";
                response.Message = (e + "Hatası");
               
            }
            return response;
        }

      
         
            
        

        public AddCartResponse AddCart(AddCartRequest request)
        {
            var response = new AddCartResponse();
            try
            {
                var validator = new AddCartValidator();
                var validatorResult = validator.Validate(request);
                var product = new Product();
                product.Id = request.Id;
                product.Id = request.ProductId;

                product.Name = request.Name;
                product.Quantity = request.Quantity;

                _productRepository.Add(product);
                response.Code = "200";
                response.Message = "ürün sepete eklendi ";
                return response;


            }
            catch (Exception e)
            {
                response.Message = e + " Hatası";
                response.Code = "400";
                return response;
            }
        }

    }

      
}
