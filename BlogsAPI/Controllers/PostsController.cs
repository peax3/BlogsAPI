using System;
using System.Threading.Tasks;
using BlogsAPI.Contracts;
using BlogsAPI.DBContext;
using BlogsAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogsAPI.Controllers
{
    public class PostsController : BaseController
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]PostCreationDto postCreationDto)
        {
            try
            {
                return HandleResponse(await _postRepository.CreatePost(postCreationDto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new { Message = "An Error Occurred" });
            }
        }

        [HttpGet("postId")]
        public async Task<IActionResult> GetPost(int postId)
        {
            try
            {
                return HandleResponse(await _postRepository.GetPostById(postId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new { Message = "An Error Occurred" });
            }
        }
        
        [HttpPut("postId")]
        public async Task<IActionResult> UpdatePost(int postId, [FromBody] PostUpdateDto postUpdateDto)
        {
            try
            {
                return HandleResponse(await _postRepository.UpdatePostById(postId, postUpdateDto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new { Message = "An Error Occurred" });
            }
        }
        
        [HttpDelete("postId")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            try
            {
                return HandleResponse(await _postRepository.DeletePostById(postId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new { Message = "An Error Occurred" });
            }
        }
        
    }
}