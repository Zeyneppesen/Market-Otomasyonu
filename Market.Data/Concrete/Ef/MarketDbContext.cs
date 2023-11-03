using Market.Entity.Concrete.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Concrete.Ef
{
    public class MarketDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = 'DESKTOP-R4ITLSH,1433\\MSSQLSERVER'; Initial Catalog =MarketDBa;MultipleActiveResultSets=True; ");
        }
        public DbSet<Product> Products { get; set; }
    }
}
