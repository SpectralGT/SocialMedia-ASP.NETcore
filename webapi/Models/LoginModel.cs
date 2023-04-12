using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="email is requiered")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "epassword is requiered")]
        public string? Password { get; set; }
    }
}
