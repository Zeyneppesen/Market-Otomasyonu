using Market.Core.Data.Ef;
using Market.Data.Abstract;
using Market.Entity.Concrete.Model;


namespace Market.Data.Concrete.Ef
{
    public class EfProductRepository:EfEntityRepository<Product, MarketDbContext>, IProductRepository
    {
    }
}
