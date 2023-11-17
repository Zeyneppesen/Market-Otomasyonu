using Market.Entity.Concrete.DTO;
using Microsoft.AspNetCore.Mvc;


namespace Market.Business.Abstract
{
    public interface IProductService
    {
        GetProductResponse GetProduct([FromQuery] GetProductRequest request);
    }
}
