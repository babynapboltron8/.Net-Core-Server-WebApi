// Imports ASP.NET Core MVC classes such as:
// ControllerBase, ActionResult, HttpGet, Route, ApiController
using Microsoft.AspNetCore.Mvc;

// Imports the Post model from the Models folder
using ServerApi.Models;

// Imports the PostService class from the Services folder
using ServerApi.Services;

namespace ServerApi.Controllers
{
    // Namespace groups all controller classes together.
    // Typically matches the folder structure.
    
    // Route template:
    // [controller] becomes "posts"
    // Final route: api/posts
    [Route("api/[controller]")]
    
    // Enables API-specific features:
    // - Automatic model validation
    // - Automatic HTTP 400 responses
    // - Better API conventions
    [ApiController]
    public class PostsController : ControllerBase
    {
        // Holds a reference to the service layer.
        // Controller uses this to access business logic.
        private readonly PostService _postService;

        // Constructor
        // Runs when ASP.NET creates the controller.
        public PostsController()
        {
            // Create service instance
            _postService = new PostService();
        }

        // GET api/posts/1
        // {id} comes from the URL.
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPosts(int id)
        {
            // Ask the service for the post.
            var post = await _postService.GetPost(id);

            // Return HTTP 404 if no post found.
            if (post == null)
            {
                return NotFound();
            }

            // Return HTTP 200 and the post data.
            return Ok(post);
        }
    }
}