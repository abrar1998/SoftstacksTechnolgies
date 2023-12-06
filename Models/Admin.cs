using System.ComponentModel.DataAnnotations;

namespace SoftStacksTechnologies.Models
{
    public class Admin
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter Your Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please Enter Your DOB")]
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }
    }
}
