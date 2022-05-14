using System.ComponentModel.DataAnnotations;

namespace BlogsAPI.Dtos
{
    public class PostCreationDto
    {
        [Required(ErrorMessage = "Blog id is required")]
        public int BlogId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }
    }
}