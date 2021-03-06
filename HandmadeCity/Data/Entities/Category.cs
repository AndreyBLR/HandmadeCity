﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, DefaultValue("")]
        public string Name { get; set; }
        [DefaultValue("")]
        public string Description { get; set; }
        [Required]
        public Topic Topic { get; set; }
        [DefaultValue("")]
        public string PictureUrl { get; set; }
        public IList<Product> Products { get; set; }
    }
}
