using System.Threading.Tasks;
using BlogsAPI.Dtos;
using BlogsAPI.Helpers.cs;

namespace BlogsAPI.Contracts
{
    public interface IBlogRepository
    {
        Task<GenericResponse> CreateBlog(BlogCreationDto blogCreationDto);
    }
}