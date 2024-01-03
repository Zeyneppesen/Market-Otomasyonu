using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.Concrete.Model
{
    [Table("Categories")]
    public class Category
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("CategoryName")]
        public string CategoryName { get; set; }
        [Column("Description")]
        public string Description { get; set;}
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
