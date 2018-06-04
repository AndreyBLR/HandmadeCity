using System.Collections.Generic;
using HandmadeCity.ViewModels.Shared;

namespace HandmadeCity.ViewModels.Product
{
    public class ProductsViewModel
    {
        public IList<ProductCardViewModel> Products { get; }

        public ProductsViewModel()
        {
            Products = new List<ProductCardViewModel>();
        }

        public ProductsViewModel(IList<ProductCardViewModel> products)
        {
            Products = products;
        }

        public void AddProductviewModel(ProductCardViewModel productViewModel)
        {
            Products.Add(productViewModel);
        }
    }
}
