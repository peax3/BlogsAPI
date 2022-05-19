using System.Threading.Tasks;
using BlogsAPI.Dtos;
using BlogsAPI.Helpers.cs;
using Microsoft.AspNetCore.Mvc;

namespace BlogsAPI.Contracts
{
    public interface IAccountRepository
    {
        Task<GenericResponse> CreateUser(UserCreationDto userCreationDto);
        Task<GenericResponse> LoginUser(LoginDto loginDto);
    }
}