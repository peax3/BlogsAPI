using System.ComponentModel.DataAnnotations;

namespace BlogsAPI.Dtos
{
    public class UserCreationDto
    {
        [Required(ErrorMessage = "First name is required")]
        [MinLength(3, ErrorMessage = "First name must 3 characters")]
        public  string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        [MinLength(3, ErrorMessage = "Last name must 3 characters")]
        public  string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public  string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be more than 8 characters")]
        public  string Password { get; set; }
        
        public  string PhoneNumber { get; set; }
    }
}