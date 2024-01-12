using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.DTO
{
    public class AddProductRequest:BaseApiRequest
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string UnitPrice { get; set; }
        public int Stok { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime Expiration { get; set; }
    }
}
