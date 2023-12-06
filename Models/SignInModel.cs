using System.ComponentModel.DataAnnotations;

namespace SoftStacksTechnologies.Models
{
    public class SignInModel
    {

        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Enter valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
