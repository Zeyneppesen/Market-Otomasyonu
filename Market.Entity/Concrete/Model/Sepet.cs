using Market.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.Concrete.Model
{
    [Table("Sepets")]
   public class Sepet:BaseEntity
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("ProductId")]
        public long ProductId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }
    }
}
