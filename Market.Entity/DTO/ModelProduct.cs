using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.DTO
{
    public class ModelProduct
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int Stock { get; set; }
        public string Detail { get; set; }
        
        public bool Status { get; set; }

       
        public DateTime CreatedDate { get; set; }

       
        public DateTime ModifiedDate { get; set; }

        public DateTime DeletedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
