using ZumPostAPI.Models;

namespace ZumPostAPI
{
    public interface IGetPostModels
    { 
        Task<List<PostModel>> ReturnPostsByTag(string tag, string sortBy, string direction);
    }
}