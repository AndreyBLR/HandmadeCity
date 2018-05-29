﻿using System;
using HandmadeCity.Data.Entities;

namespace HandmadeCity.ViewModels.Shared
{
    public class ProductViewModel
    {
        public bool IsInCart { get; set; }
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

        public ProductViewModel(Product product, bool isInCart)
        {
            IsInCart = isInCart;
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            CategoryName = product?.Category?.Name;

            Discount = product.Discount;
            Price = product.Price;

            TotalRating = Convert.ToInt32(product.TotalRating);

            if(product.Reviews != null)
                ReviewAmout = product.Reviews.Count;

            PictureUrl = product.PictureUrl;
        }
    }
}
