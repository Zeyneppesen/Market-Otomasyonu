



using Market.Data;

namespace Market.Business.Abstract
{
    public interface IProductService
    {
        GetProductResponse GetProduct(GetProductRequest request);
    }
}
