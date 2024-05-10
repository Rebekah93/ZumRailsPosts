using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZumPostAPI.Services;

namespace ZumPostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(string tag, string sortBy, string direction)
        {
            var result = await _postService.GetPostsByTag(tag, sortBy, direction);

            return Ok(result);
        }
    }
}
