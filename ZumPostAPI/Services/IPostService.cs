using ZumPostAPI.Models;

namespace ZumPostAPI.Services
{
    public interface IPostService
    {
        Task<List<PostModel>> GetPostsByTag(string tag, string sortBy, string description);
    }
}