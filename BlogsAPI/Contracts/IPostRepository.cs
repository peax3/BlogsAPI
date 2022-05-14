using System.Threading.Tasks;
using BlogsAPI.Dtos;
using BlogsAPI.Helpers.cs;

namespace BlogsAPI.Contracts
{
    public interface IPostRepository
    {
        Task<GenericResponse> GetPostById(int postId);
        Task<GenericResponse> CreatePost(PostCreationDto postCreationDto);
        Task<GenericResponse> UpdatePostById(int postId, PostUpdateDto postUpdateDto);
        Task<GenericResponse> DeletePostById(int postId);
    }
}