using System.ComponentModel.DataAnnotations;

namespace Gighub.ViewModels
{

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
