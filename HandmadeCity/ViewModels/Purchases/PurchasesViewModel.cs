using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.ViewModels.Shared;

namespace HandmadeCity.ViewModels.Purchases
{
    public class PurchasesViewModel
    {
        public IList<PurchaseCardViewModel> Purchases { get; }

        public PurchasesViewModel()
        {
            Purchases = new List<PurchaseCardViewModel>();
        }

        public PurchasesViewModel(IList<PurchaseCardViewModel> products)
        {
            Purchases = products;
        }

        public void AddPurchaseViewModel(PurchaseCardViewModel purchaseViewModel)
        {
            Purchases.Add(purchaseViewModel);
        }
    }
}
