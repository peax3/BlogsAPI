using System.ComponentModel.DataAnnotations;

namespace BlogsAPI.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public  string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be more than 8 characters")]
        public  string Password { get; set; }
    }
}