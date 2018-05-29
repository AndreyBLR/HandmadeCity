using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.ViewModels.Purchases
{
    public class PurchaseHistoryViewModel
    {
        public IList<PurchaseViewModel> Purchases { get; }

        public PurchaseHistoryViewModel()
        {
            Purchases = new List<PurchaseViewModel>();
        }

        public PurchaseHistoryViewModel(IList<PurchaseViewModel> products)
        {
            Purchases = products;
        }

        public void AddPurchaseViewModel(PurchaseViewModel purchaseViewModel)
        {
            Purchases.Add(purchaseViewModel);
        }
    }
}
