using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class RegistrationModel
    {
        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
