using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HandmadeCity.Data.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public IList<Review> Reviews { get; set; }
        public IList<Bookmark> Bookmarks { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
