using System;
using System.Threading.Tasks;
using BlogsAPI.Contracts;
using BlogsAPI.Dtos;
using BlogsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogsAPI.Controllers
{
    //[Route("api/[Controller]")]
    public class BlogsController : BaseController
    {
        private readonly IBlogRepository _blogRepository;
        private readonly UserManager<User> _userManager;

        public BlogsController(IBlogRepository blogRepository, UserManager<User> userManager)
        {
            _blogRepository = blogRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBlog([FromBody]BlogCreationDto blogCreationDto)
        {
            try
            {
                //var id = User.FindFirst("id").ToString();
                
                var response = await _blogRepository.CreateBlog(blogCreationDto);
                return HandleResponse(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new {Message = "An Error Occurred"});
            }
        }
    }
}