using ZumPostAPI.Models;

namespace ZumPostAPI.Services
{
    public class PostService : IPostService
    {
        private static IGetPostModels _getPostModels;

        public PostService(IGetPostModels getPostModels)
        {
            _getPostModels = getPostModels;
        }

        public async Task<List<PostModel>> GetPostsByTag(string tag, string sortBy, string description)
        {
            return await _getPostModels.ReturnPostsByTag(tag, sortBy , description);
        }
    }
}
