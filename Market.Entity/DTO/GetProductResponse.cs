using Market.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity
{
    public class GetProductResponse : BaseApiResponse
    {
       // public List<ProductModal> Products { get; set; }
        public List<ModelProduct> ProductModels { get; set; }
    }
    }
       