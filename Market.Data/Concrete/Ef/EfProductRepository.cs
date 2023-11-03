using Market.Core.Data.Ef;
using Market.Data.Abstract;
using Market.Data.Concrete.Ef;
using Market.Entity.Concrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Concrete.Ef
{
    public class EfProductRepository: EfEntityRepository<Product, MarketDbContext>, IProductRepository
    {
    
    }
}
