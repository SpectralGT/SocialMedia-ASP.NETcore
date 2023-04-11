using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace webapi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="email is requiered")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "epassword is requiered")]
        public string? Password { get; set; }
    }
}
