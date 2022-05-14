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
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}