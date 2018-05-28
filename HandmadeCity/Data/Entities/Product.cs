using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue("")]
        public string Description { get; set; }
        [Required, DefaultValue(0)]
        public decimal Price { get; set; }
        [DefaultValue(0)]
        public int Discount { get; set; }
        [DefaultValue(0)]
        public float TotalRating { get; set; }
        [DefaultValue("")]
        public string PictureUrl { get; set; }
        public IList<Order> Orders { get; set; }
        public IList<Bookmark> Bookmarks { get; set; }
        public IList<Review> Reviews { get; set; }
        public Category Category { get; set; }
    }
}
