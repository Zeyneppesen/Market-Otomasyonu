using Market.Business.Abstract;
using Market.Data.Abstract;
using Market.Entity.Concrete.DTO;


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
                        model.CategoryId = productModule.CategoryId;
                        model.Name = productModule.Name;
                        model.UnitPrice = productModule.UnitPrice;
                        model.Stock = productModule.Stok;
                        model.Detail = productModule.Detail;
                        model.InDate = productModule.InDate;
                        model.OutDate = productModule.OutDate;
                        model.ExpirationDate = productModule.ExpirationDate;

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
