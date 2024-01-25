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
        [Column("Id")]
        public long Id { get; set; }
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

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }

        [Column("deleted_date")]
        public DateTime DeletedDate { get; set; }
        [Column("ExpirationDate")] // Son kullanma
        public DateTime? ExpirationDate { get; set; }//
        [Column("Quantity")]
        public int Quantity { get; set; }
        public virtual Category Category { get; set; }
        public virtual Sepet Sepet { get; set; }
      

    }
}