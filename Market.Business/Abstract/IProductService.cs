using Market.Data;
using Market.Entity;
using Market.Entity.DTO;

namespace Market.Business.Abstract
{
    public interface IProductService
    {
        GetProductResponse GetList(GetProductRequest request);
        GetProductResponse GetCategory(GetProductRequest request, long categoryId);
        GetProductResponse GetProductExp(GetProductRequest request, string productName);
   
        AddProductResponse AddProduct(AddProductRequest request);
        SellProductResponse SellProduct(SellProductRequest request);
        AddBasketResponse AddBasket(AddBasketRequest request);
    }
}

