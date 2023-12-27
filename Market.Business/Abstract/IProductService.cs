
using Market.Data;
using Market.Entity;

namespace Market.Business.Abstract
{
    public interface IProductService
    {
        GetProductResponse GetList(GetProductRequest request);
    }
}
