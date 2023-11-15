using Market.Entity.Concrete.DTO;


namespace Market.Business.Abstract
{
    public interface IProductService
    {
        GetProductResponse GetProduct(GetProductRequest request);
    }
}
