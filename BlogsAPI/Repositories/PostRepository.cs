using BlogsAPI.Contracts;
using BlogsAPI.DBContext;
using BlogsAPI.Dtos;
using BlogsAPI.Helpers.cs;
using BlogsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogsAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<User> _userManager;

        public PostRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<GenericResponse> GetPostById(int postId)
        {
            var existingPost = await _appDbContext.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
            if (existingPost == null) return new GenericResponse { StatusCode = 404, Data = null };

            var responseData = new PostResponseDto()
            {
                PostId = existingPost.PostId,
                BlogId = existingPost.BlogId,
                Body = existingPost.Body,
                Title = existingPost.Title,
                CreatedAt = existingPost.CreatedAt,
                LastUpdatedAt = existingPost.LastUpdatedAt
            };

            return new GenericResponse() { StatusCode = 200, Data = responseData };
        }

        public async Task<GenericResponse> CreatePost(PostCreationDto postCreationDto)
        {
            var id = _httpContext.HttpContext.User.FindFirst("id").Value;

            var existingUser = await _userManager.Users.Include(u => u.Blogs).FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null) return new GenericResponse { StatusCode = 400, Data = null };

            if (!existingUser.Blogs.Any(b => b.Id == postCreationDto.BlogId))
            {
                return new GenericResponse { StatusCode = 403, Data = null };
            }

            var existingBlog = await _appDbContext.Blogs.FirstOrDefaultAsync(b => b.Id == postCreationDto.BlogId);
            if (existingBlog == null)
            {
                return new GenericResponse
                {
                    StatusCode = 404,
                    Data = null
                };
            }

            //if(!_appDbContext.Blogs.Any(b => b.Id == postCreationDto.BlogId)))   return new GenericResponse { StatusCode = 404, Data = null };

            var newPost = new Post()
            {
                Title = postCreationDto.Title,
                Body = postCreationDto.Body,
                CreatedAt = DateTime.Now,
                BlogId = postCreationDto.BlogId
            };

            await _appDbContext.Posts.AddAsync(newPost);
            await _appDbContext.SaveChangesAsync();

            var responseData = new PostResponseDto()
            {
                PostId = newPost.PostId,
                BlogId = newPost.BlogId,
                Body = newPost.Body,
                Title = newPost.Title,
                CreatedAt = newPost.CreatedAt,
                LastUpdatedAt = newPost.LastUpdatedAt
            };

            return new GenericResponse() { StatusCode = 200, Data = responseData };
        }

        public async Task<GenericResponse> UpdatePostById(int postId, PostUpdateDto postUpdateDto)
        {
            var id = _httpContext.HttpContext.User.FindFirst("id").Value;

            var existingUser = await _userManager.Users.Include(u => u.Blogs).ThenInclude(b => b.BlogPosts).FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null) return new GenericResponse { StatusCode = 400, Data = null };

            var existingPost = await _appDbContext.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
            if (existingPost == null) return new GenericResponse { StatusCode = 404, Data = null };

            if (!existingUser.Blogs.Any(b => b.Id == existingPost.BlogId))
            {
                return new GenericResponse { StatusCode = 403, Data = null };
            }

            existingPost.Title = postUpdateDto.Title;
            existingPost.Body = postUpdateDto.Body;
            existingPost.LastUpdatedAt = DateTime.Now;

            await _appDbContext.SaveChangesAsync();

            return new GenericResponse() { StatusCode = 200, Data = null };
        }

        public async Task<GenericResponse> DeletePostById(int postId)
        {
            var existingPost = await _appDbContext.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
            if (existingPost == null) return new GenericResponse { StatusCode = 404, Data = null };

            _appDbContext.Remove(existingPost);
            await _appDbContext.SaveChangesAsync();

            return new GenericResponse() { StatusCode = 200, Data = null };
        }
    }
}