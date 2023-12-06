using System.ComponentModel.DataAnnotations;

namespace SoftStacksTechnologies.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage ="Please Enter Your Email")]
        [EmailAddress(ErrorMessage ="Enter valid Email Address")]
        public string Email {  get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password Doesn't Match")]
        public string ConfirmPassword {  get; set; }

        public Role Role { get; set; }
    }

    public enum Role
    { 
        Admin,
        Teacher,
        Student
    }
}
