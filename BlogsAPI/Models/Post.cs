using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogsAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        
        // foreign key
        public int BlogId { get; set; }
        
        // relationship
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
    }
}