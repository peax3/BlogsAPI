using System.ComponentModel.DataAnnotations;

namespace BlogsAPI.Dtos
{
    public class PostUpdateDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }
    }
}