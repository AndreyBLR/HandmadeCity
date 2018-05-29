using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandmadeCity.Data.Entities
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public IList<PurchaseProduct> PurchaseProducts { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [DefaultValue(0)]
        public decimal TotalCost { get; set; }
    }
}
