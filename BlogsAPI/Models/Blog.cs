using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogsAPI.Models
{
    public class Blog
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        
        // relationship
        public ICollection<Post> BlogPosts { get; set; }
        
        // public Blog()
        // {
        //     this.CreatedAt = DateTime.Now;
        // }
    }
}