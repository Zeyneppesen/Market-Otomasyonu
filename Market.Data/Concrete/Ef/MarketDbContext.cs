using Market.Entity.Concrete.Model;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Concrete.Ef
{

    public class MarketDbContext:DbContext
    {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
      
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R4ITLSH; Initial Catalog=MarketDB; Integrated Security=True; TrustServerCertificate=True");

         
        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Sepet> Sepets { get; set; }
   
    }
}
