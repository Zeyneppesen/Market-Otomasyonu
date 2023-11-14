using Market.Entity.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Abstract
{
    public interface IProductService
    {
        GetProductResponse GetProduct(GetProductRequest request);
    }
}
