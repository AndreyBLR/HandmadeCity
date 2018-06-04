using System;
using System.Collections.Generic;
using HandmadeCity.Data.Entities;

namespace HandmadeCity.ViewModels.Shared
{
    public class PurchaseCardViewModel
    {
        public int Id { get; }
        public DateTime DateTime { get; }
        public IList<ProductCardViewModel> ProductsList { get; }
        public decimal TotalCost { get; }

        public PurchaseCardViewModel()
        {
        }

        public PurchaseCardViewModel(Purchase purchase)
        {
            Id = purchase.Id;
            DateTime = purchase.DateTime;
            TotalCost = purchase.TotalCost;
            ProductsList = new List<ProductCardViewModel>();

            foreach (var purchaseProduct in purchase.PurchaseProducts)
            {
                ProductsList.Add(new ProductCardViewModel(purchaseProduct.Product));
            }
        }
    }
}
