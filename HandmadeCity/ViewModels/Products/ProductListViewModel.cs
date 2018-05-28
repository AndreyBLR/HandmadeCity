﻿using System.Collections.Generic;
using HandmadeCity.Data.Entities;
using HandmadeCity.ViewModels.Shared;

namespace HandmadeCity.ViewModels.Products
{
    public class ProductListViewModel
    {
        public IList<ProductViewModel> Products { get; }

        public ProductListViewModel()
        {
            Products = new List<ProductViewModel>();
        }

        public ProductListViewModel(IList<ProductViewModel> products)
        {
            Products = products;
        }

        public void AddProductviewModel(ProductViewModel productViewModel)
        {
            Products.Add(productViewModel);
        }
    }
}
