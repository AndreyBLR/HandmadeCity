using System.ComponentModel.DataAnnotations;

namespace HandmadeCity.ViewModels.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
