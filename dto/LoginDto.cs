using System.ComponentModel.DataAnnotations;

namespace Zaghini.Mattia._5H.SecondaWeb.dto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Ricordami")]
        public bool RememberMe { get; set; }
    }
}
