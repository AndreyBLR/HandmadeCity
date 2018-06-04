using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HandmadeCity.Data.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public IList<Review> Reviews { get; set; }
        public IList<Purchase> Orders { get; set; }
    }
}
