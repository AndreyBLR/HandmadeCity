﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.Data.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required, DefaultValue("")]
        public string Text { get; set; }
        [Required, DefaultValue(0)]
        public int Rating { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public Product Product { get; set; }
    }
}
