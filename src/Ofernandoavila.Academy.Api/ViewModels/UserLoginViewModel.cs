using System.ComponentModel.DataAnnotations;

namespace Ofernandoavila.Academy.API.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name = "User")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The field {0} must have between {2} and {1} characters.")]
        public string User { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Password { get; set; }
    }
}
