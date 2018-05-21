using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.Data.Entities
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Order Order { get; set; }
        [Required]
        public Product Product { get; set; }
    }
}
