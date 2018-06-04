using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.ViewModels.Purchases
{
    public class PurchaseViewModel
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
