using System.ComponentModel.DataAnnotations;

namespace FinalProjectWeek9.ViewModels
{
    public class SignUpViewModel
    {
        [Required]  // Indicates that this field is required
        [Display(Name = "Full Name")]  // Display name for the field
        public string FullName { get; set; }  // User's full name

        [Required]  // Indicates that this field is required
        [EmailAddress]  // Validates that the field contains a valid email address
        [Display(Name = "Email")]  // Display name for the field
        public string Email { get; set; }  // User's email address

        [Required]  // Indicates that this field is required
        [DataType(DataType.Password)]  // Specifies that the field is a password
        [Display(Name = "Password")]  // Display name for the field
        public string Password { get; set; }  // User's password

        [Required]  // Indicates that this field is required
        [DataType(DataType.Password)]  // Specifies that the field is a password
        [Display(Name = "Confirm Password")]  // Display name for the field
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]  // Ensures the confirmation password matches the original password
        public string ConfirmPassword { get; set; }  // User's confirmation password
    }
}
