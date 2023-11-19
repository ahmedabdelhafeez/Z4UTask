

using System.ComponentModel.DataAnnotations;

namespace Task.Domain.Services.AuthDomain.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Please Add Your UserName Or Email")]
        [Display(Name ="UserName/Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Please Add Your Password")]
        [MinLength(6, ErrorMessage = "Password must be More Than 5 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
