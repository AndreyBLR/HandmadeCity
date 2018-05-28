using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data.Entities;
using HandmadeCity.ViewModels.Shared;

namespace HandmadeCity.ViewModels.Cart
{
    public class CartListViewModel
    {
        public IList<ProductViewModel> Products { get; set; }

        public CartListViewModel()
        {
            Products = new List<ProductViewModel>();
        }

        public CartListViewModel(IList<ProductViewModel> products)
        {
            Products = products;
        }

        public void AddProductviewModel(ProductViewModel productViewModel)
        {
            Products.Add(productViewModel);
        }
    }
}
