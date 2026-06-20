using Microsoft.AspNetCore.Mvc;
using ServerApi.Models;
using ServerApi.Services;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;

        public PostsController()
        {
            _postService = new PostService();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Post>>> GetPosts(int id)
        {
            var post = await _postService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}