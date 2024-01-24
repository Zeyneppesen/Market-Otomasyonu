﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entity.DTO
{
   public class AddCartRequest:BaseApiRequest
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
