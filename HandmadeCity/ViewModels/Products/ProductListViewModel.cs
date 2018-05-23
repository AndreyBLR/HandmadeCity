using System.Collections.Generic;
using HandmadeCity.Data.Entities;

namespace HandmadeCity.ViewModels.Products
{
    public class ProductListViewModel
    {
        public IList<ProductViewModel> Products { get; set; }

        public ProductListViewModel()
        {
        }

        public ProductListViewModel(IList<Product> products)
        {
            Products = new List<ProductViewModel>();

            foreach (var product in products)
            {
                Products.Add(new ProductViewModel(product));
            }
        }
    }
}
