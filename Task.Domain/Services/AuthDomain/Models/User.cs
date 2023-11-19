
using System.ComponentModel.DataAnnotations;

namespace Task.Domain.Services.AuthDomain.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please Add Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Add Your Email")]
        [EmailAddress(ErrorMessage = "Please Add a Valid Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Please Add Your Password")]
        [MinLength(6, ErrorMessage = "Password must be More Than 5 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
