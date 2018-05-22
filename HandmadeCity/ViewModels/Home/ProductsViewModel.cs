using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data.Entities;

namespace HandmadeCity.ViewModels.Home
{
    public class ProductsViewModel
    {
        public IList<Product> Products { get; set; }
    }
}
