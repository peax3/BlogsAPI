using BlogsAPI.Contracts;
using BlogsAPI.DBContext;
using BlogsAPI.Dtos;
using BlogsAPI.Helpers.cs;
using BlogsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogsAPI.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<User> _userManager;

        public BlogRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<GenericResponse> CreateBlog(BlogCreationDto blogCreationDto)
        {
            var id = _httpContext.HttpContext.User.FindFirst("id").Value;

            var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null) return new GenericResponse { StatusCode = 400, Data = null };

            var newBlog = new Blog()
            {
                Name = blogCreationDto.Name,
                CreatedAt = DateTime.Now,
                User = existingUser
            };

            await _appDbContext.Blogs.AddAsync(newBlog);
            await _appDbContext.SaveChangesAsync();

            return new GenericResponse
            {
                StatusCode = 200,
                Data = new BlogCreationResponseDto()
                {
                    Id = newBlog.Id,
                    Name = newBlog.Name,
                    CreatedAt = newBlog.CreatedAt
                }
            };
        }
    }
}