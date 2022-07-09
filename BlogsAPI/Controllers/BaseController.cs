using System;
using BlogsAPI.Helpers.cs;
using Microsoft.AspNetCore.Mvc;

namespace BlogsAPI.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleResponse(GenericResponse response)
        {
            switch (response.StatusCode)
            {
                case 200:
                    return Ok(response.Data);
                case 404:
                    return NotFound();
                case 400:
                    return BadRequest(response.Data);
                case 403:
                    return new ForbidResult();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}