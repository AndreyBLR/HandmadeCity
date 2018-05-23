using System.Collections.Generic;
using HandmadeCity.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HandmadeCity.ViewModels.Products
{
    public class ProductForAddingViewModel
    {
        public IFormFile Image { get; set; }

        public int SelectedCategoryId { get; set; }
        public SelectList Categories { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int Discount { get; set; }
        public decimal Price { get; set; }

        public ProductForAddingViewModel()
        {
        }

        public ProductForAddingViewModel(IList<Category> categories)
        {
            Categories = new SelectList(categories, "Id", "Name");
        }
    }
}
