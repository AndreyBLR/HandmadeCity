using System;
using System.Collections.Generic;
using System.Linq;
using HandmadeCity.Data.Entities;

namespace HandmadeCity.ViewModels.Product
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
        public IList<Review> Reviews { get; set; }

        public string PictureUrl { get; set; }

        public bool IsInCart { get; set; }

        public AddReviewViewModel AddReviewViewModel { get; set; }

        public ProductViewModel()
        {
            AddReviewViewModel = new AddReviewViewModel();
        }

        public ProductViewModel(Data.Entities.Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            CategoryName = product.Category.Name;

            Discount = product.Discount;
            Price = product.Price;

            Reviews = product.Reviews;
            TotalRating = TotalRating = product.Reviews.Count != 0 ? product.Reviews.Sum(rev => rev.Rating) / product.Reviews.Count : 0;

            PictureUrl = product.PictureUrl;

            AddReviewViewModel = new AddReviewViewModel();
        }
    }
}
