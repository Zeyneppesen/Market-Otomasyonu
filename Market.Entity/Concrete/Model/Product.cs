using Market.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.Concrete.Model
{
    [Table("Products")]
    public class Product:BaseEntity
    {

        [Column("CategoryId")]
        public long CategoryId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("UnitPrice")]
        public int UnitPrice { get; set; }
        [Column("Stock")]
        public int Stok { get; set; }
        [Column("Detail")]
        public string Detail { get; set; }

    }
}