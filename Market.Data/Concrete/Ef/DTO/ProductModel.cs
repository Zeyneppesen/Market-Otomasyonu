using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.Concrete.DTO
{
    public class ProductModal
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int Stock { get; set; }
        public string Detail { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public DateTime ExpirationDate { get; set; }


    }
}
