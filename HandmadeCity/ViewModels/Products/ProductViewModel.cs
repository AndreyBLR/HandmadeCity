using System;
using HandmadeCity.Data.Entities;

namespace HandmadeCity.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int Discount { get; set; }
        public decimal Price { get; set; }

        public int TotalRating { get; set; }
        public int ReviewAmout { get; set; }

        public string PictureUrl { get; set; }

        public ProductViewModel()
        {
        }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            CategoryName = product.Category.Name;

            Discount = product.Discount;
            Price = product.Price;

            TotalRating = Convert.ToInt32(product.TotalRating);

            ReviewAmout = product.Reviews.Count;

            PictureUrl = product.PictureUrl;
        }
    }
}
