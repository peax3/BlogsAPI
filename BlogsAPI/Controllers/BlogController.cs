using System;
using System.Threading.Tasks;
using BlogsAPI.Contracts;
using BlogsAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlogsAPI.Controllers
{
    //[Route("api/[Controller]")]
    public class BlogsController : BaseController
    {
        private readonly IBlogRepository _blogRepository;

        public BlogsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody]BlogCreationDto blogCreationDto)
        {
            try
            {
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