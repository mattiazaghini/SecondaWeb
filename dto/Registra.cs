using System.ComponentModel.DataAnnotations;

namespace Zaghini.Mattia._5H.SecondaWeb.dto
{
    public class RegistraDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Le password non corrispondono")]
        public string ConfirmPassword { get; set; }
    }
}