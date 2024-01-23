using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.DTO
{
    public class AddCartResponse:BaseApiResponse
    {
         //public List<ModelProduct> ProductModels { get; set; }
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
