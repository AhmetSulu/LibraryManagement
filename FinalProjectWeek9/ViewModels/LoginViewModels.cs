using System.ComponentModel.DataAnnotations;

namespace FinalProjectWeek9.ViewModels
{
    public class LoginViewModel
    {
        [Required]  // Indicates that this field is required
        [EmailAddress]  // Validates that the field contains a valid email address
        [Display(Name = "Email")]  // Display name for the field
        public string Email { get; set; }  // User's email address

        [Required]  // Indicates that this field is required
        [DataType(DataType.Password)]  // Specifies that the field is a password
        [Display(Name = "Password")]  // Display name for the field
        public string Password { get; set; }  // User's password
    }
}
