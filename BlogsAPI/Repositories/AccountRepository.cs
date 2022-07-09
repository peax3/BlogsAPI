using BlogsAPI.Contracts;
using BlogsAPI.Dtos;
using BlogsAPI.Helpers.cs;
using BlogsAPI.Models;
using BlogsAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogsAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;

        public AccountRepository(UserManager<User> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<GenericResponse> CreateUser(UserCreationDto userCreationDto)
        {
            var newUser = new User
            {
                FirstName = userCreationDto.FirstName,
                LastName = userCreationDto.LastName,
                Email = userCreationDto.Email,
                PhoneNumber = userCreationDto.PhoneNumber,
                UserName = userCreationDto.Email
            };

            var result = await _userManager.CreateAsync(newUser, userCreationDto.Password);

            return result.Succeeded
                ? new GenericResponse() { StatusCode = 200, Data = new { newUserId = newUser.Id } }
                : new GenericResponse() { StatusCode = 400, Data = result.Errors };
        }

        public async Task<GenericResponse> LoginUser(LoginDto loginDto)
        {
            // check if a user with the email exist
            var existingUser =
                await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == loginDto.Email.ToUpper());

            //var allExistingUsers = await _userManager.Users.ToListAsync();

            //var existingUser = allExistingUsers.Find(u =>
            //string.Compare(u.Email, loginDto.Email, StringComparison.OrdinalIgnoreCase) == 0);

            if (existingUser == null) return new GenericResponse { StatusCode = 404, Data = null };

            // check if password that comes with email is valid
            var isPasswordValid = await _userManager.CheckPasswordAsync(existingUser, loginDto.Password);

            if (!isPasswordValid) return new GenericResponse { StatusCode = 400 };

            // at this point - the login details passed is valid

            var token = await _tokenService.GenerateToken(existingUser);

            return new GenericResponse
            {
                StatusCode = 200,
                Data = new UserResponseDto
                {
                    UserId = existingUser.Id,
                    FirstName = existingUser.FirstName,
                    LastName = existingUser.LastName,
                    Email = existingUser.Email,
                    PhoneNumber = existingUser.PhoneNumber,
                    Token = token
                }
            };
        }
    }
}