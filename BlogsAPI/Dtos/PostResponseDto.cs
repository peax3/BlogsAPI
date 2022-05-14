using System;

namespace BlogsAPI.Dtos
{
    public class PostResponseDto
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

    }
}