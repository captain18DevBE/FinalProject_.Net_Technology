using System.ComponentModel.DataAnnotations;

namespace MusicWeb.Models.DTO
{
    public class RegistrationModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one digit.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }
        public string ? Role { get; set; }
    }
}
