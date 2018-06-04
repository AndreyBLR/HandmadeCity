using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data.Entities;
using HandmadeCity.ViewModels.Purchases;
using HandmadeCity.ViewModels.Shared;

namespace HandmadeCity.ViewModels.Cart
{
    public class CartViewModel
    {
        public IList<ProductCardViewModel> Products { get; set; }
        public PurchaseViewModel PurchaseViewModel { get; set; }

        public CartViewModel()
        {
            Products = new List<ProductCardViewModel>();
            PurchaseViewModel = new PurchaseViewModel();
        }

        public CartViewModel(IList<ProductCardViewModel> products)
        {
            Products = products;
            PurchaseViewModel = new PurchaseViewModel();
        }

        public void AddProductviewModel(ProductCardViewModel productViewModel)
        {
            Products.Add(productViewModel);
        }
    }
}
