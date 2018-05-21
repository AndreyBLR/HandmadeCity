﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public IList<OrderProduct> OrderProducts { get; set; }
        [DefaultValue(0)]
        public decimal TotalCost { get; set; }
    }
}