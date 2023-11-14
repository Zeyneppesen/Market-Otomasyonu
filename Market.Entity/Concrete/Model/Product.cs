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
    public class Product:IEntity
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("CategoryId")]
        public long CategoryId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("UnitPrice")]
        public int UnitPrice { get; set; }
        [Column("Stok")]
        public int Stok { get; set; }
        [Column("Detail")]
        public string Detail { get; set; }
        [Column("InDate")]
        public DateTime InDate { get; set; }
        [Column("OutDate")]
        public DateTime OutDate { get; set; }
        [Column("ExpirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}