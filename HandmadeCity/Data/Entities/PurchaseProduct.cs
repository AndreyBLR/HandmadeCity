using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.Data.Entities
{
    public class PurchaseProduct
    {
        public int OrderId { get; set; }
        public Purchase Purchase { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
