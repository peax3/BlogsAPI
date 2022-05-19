using System;
using System.Threading.Tasks;
using BlogsAPI.Contracts;
using BlogsAPI.Dtos;
using BlogsAPI.Helpers.cs;
using BlogsAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogsAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody]UserCreationDto userCreationDto)
        {
            try
            {
                return HandleResponse(await _accountRepository.CreateUser(userCreationDto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new { Message = "An Error Occurred" });
            }
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody]LoginDto loginDto)
        {
            return HandleResponse(await _accountRepository.LoginUser(loginDto));
        }
    }
}