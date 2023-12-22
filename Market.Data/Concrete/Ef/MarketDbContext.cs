using Market.Entity.Concrete.Model;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Concrete.Ef
{

    public class MarketDbContext:DbContext
    {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Data Source = 'DESKTOP-R4ITLSH,1433\\MSSQLSERVER'; Initial Catalog =MarketDB;MultipleActiveResultSets=True; ");
          //  optionsBuilder.UseSqlServer("Data Source = DESKTOP-R4ITLSH; Initial Catalog =MarketDB;MultipleActiveResultSets=True; ");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R4ITLSH; Initial Catalog=MarketDbContext; Integrated Security=True; TrustServerCertificate=True");


        }

        public DbSet<Product> Products { get; set; } 
   
    }
}
