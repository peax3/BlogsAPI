using System;
using System.Collections.Generic;
using BlogsAPI.Models;

namespace BlogsAPI.Dtos
{
    public class BlogCreationResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}