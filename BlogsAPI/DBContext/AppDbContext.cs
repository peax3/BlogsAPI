using BlogsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogsAPI.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }
        
        
        
        public DbSet<Blog> Blogs { get; set; }
        public  DbSet<Post> Posts { get; set; }
    }
}