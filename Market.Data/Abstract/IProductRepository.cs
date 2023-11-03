using Market.Core.Abstract;
using Market.Entity.Concrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
    }
}
