using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BlogsAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}