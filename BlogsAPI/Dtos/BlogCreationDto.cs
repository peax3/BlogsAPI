using System.ComponentModel.DataAnnotations;

namespace BlogsAPI.Dtos
{
    public class BlogCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        public  string Name { get; set; }
    }
}