using System.ComponentModel.DataAnnotations;

namespace HandmadeCity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
