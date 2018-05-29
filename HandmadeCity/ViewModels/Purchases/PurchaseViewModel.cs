using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data.Entities;
using HandmadeCity.ViewModels.Shared;

namespace HandmadeCity.ViewModels.Purchases
{
    public class PurchaseViewModel
    {
        public int Id { get; }
        public DateTime DateTime { get; }
        public IList<ProductViewModel> ProductsList { get; }
        public decimal TotalCost { get; }

        public PurchaseViewModel()
        {
            
        }

        public PurchaseViewModel(Purchase purchase)
        {
            Id = purchase.Id;
            DateTime = purchase.DateTime;
            TotalCost = purchase.TotalCost;
            ProductsList = new List<ProductViewModel>();

            foreach (var purchaseProduct in purchase.PurchaseProducts)
            {
                ProductsList.Add(new ProductViewModel(purchaseProduct.Product, false));
            }
        }
    }
}
