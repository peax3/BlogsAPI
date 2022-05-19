using System;
using System.Threading.Tasks;
using BlogsAPI.Contracts;
using BlogsAPI.DBContext;
using BlogsAPI.Dtos;
using BlogsAPI.Helpers.cs;
using BlogsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogsAPI.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task<GenericResponse> CreateBlog(BlogCreationDto blogCreationDto)
        {

                var newBlog = new Blog()
                {
                    Name = blogCreationDto.Name,
                    CreatedAt = DateTime.Now,
                };

                await _appDbContext.Blogs.AddAsync(newBlog);
                await _appDbContext.SaveChangesAsync();

                return new GenericResponse
                {
                    StatusCode = 200,
                    Data =  new BlogCreationResponseDto()
                    {
                        Id = newBlog.Id,
                        Name = newBlog.Name,
                        CreatedAt = newBlog.CreatedAt
                    }
                };

        }
    }
}