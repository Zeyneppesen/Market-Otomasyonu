using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.Concrete.DTO
{
    public class GetProductResponse : BaseApiResponse
    {
        public List<ProductModal> Products { get; set; }
    }
    }
       