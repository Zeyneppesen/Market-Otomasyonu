using Market.Core.Data.Ef;
using Market.Data.Abstract;
using Market.Data.Concrete.Ef;
using Market.Entity.Concrete.Model;


namespace Market.Entity
{
    public class EfProductRepository:EfEntityRepository<Product, MarketDbContext>, IProductRepository
    {
    }
}
