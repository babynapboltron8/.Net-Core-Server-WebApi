// Imports ASP.NET Core MVC classes such as:
// ControllerBase, ActionResult, HttpGet, HttpPost, HttpPut,
// Route, ApiController, Ok(), NotFound(), BadRequest(), etc.
using Microsoft.AspNetCore.Mvc;

// Imports the Post model from the Models folder.
using ServerApi.Models;

// Imports the PostService class from the Services folder.
using ServerApi.Services;

namespace ServerApi.Controllers
{
    // Groups related controller classes together.
    // Usually matches the project folder structure.

    // Defines the base route for this controller.
    // [controller] is replaced by the controller name
    // without the "Controller" suffix.
    //
    // PostsController -> api/posts
    [Route("api/[controller]")]

    // Enables API-specific behaviors:
    // - Automatic model validation
    // - Automatic HTTP 400 responses
    // - Binding request data automatically
    [ApiController]
    public class PostsController : ControllerBase
    {
        // Service layer dependency.
        // Controllers should delegate business logic
        // to services rather than implementing it directly.
        private readonly PostService _postService;

        // Constructor
        // Runs automatically whenever ASP.NET Core
        // creates an instance of this controller.
        public PostsController()
        {
            // Create a new PostService object.
            // In real-world applications, Dependency Injection (DI)
            // is usually preferred instead of using 'new'.
            _postService = new PostService();
        }

        // ==================================================
        // GET: api/posts?id=1
        // ==================================================
        //
        // Handles HTTP GET requests.
        //
        // Example:
        // GET /api/posts?id=1
        //
        // Returns a single post based on the provided ID.
        [HttpGet]
        public async Task<ActionResult<Post>> GetPosts(int id)
        {
            // Call the service layer to retrieve the post.
            var post = await _postService.GetPost(id);

            // Return HTTP 200 OK with the post data.
            return Ok(post);
        }

        // ==================================================
        // POST: api/posts
        // ==================================================
        //
        // Handles HTTP POST requests.
        //
        // Used to create a new post.
        //
        // Example Request Body:
        // {
        //   "title": "My First Post",
        //   "content": "Hello World"
        // }
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            // Call the service layer to save the new post.
            await _postService.CreatePost(post);

            // Return HTTP 201 Created.
            //
            // CreatedAtAction creates a Location header
            // pointing to the endpoint that can retrieve
            // the newly created resource.
            //
            // Example:
            // Location: /api/posts?id=1
            return CreatedAtAction(
                nameof(GetPosts),
                new { id = post.Id },
                post
            );
        }

        // ==================================================
        // PUT: api/posts/1
        // ==================================================
        //
        // Handles HTTP PUT requests.
        //
        // Used to update an existing post.
        //
        // Example:
        // PUT /api/posts/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, Post post)
        {
            // Validate that the route ID matches
            // the ID inside the request body.
            //
            // Example:
            // URL: /api/posts/1
            // Body: { "id": 2, ... }
            //
            // This would be invalid.
            if (id != post.Id)
            {
                return BadRequest();
            }

            // Call the service layer to update the post.
            var updatedPost = await _postService.UpdatePost(id, post);

            // If no post was found with the given ID,
            // return HTTP 404 Not Found.
            if (updatedPost == null)
            {
                return NotFound();
            }

            // Return HTTP 200 OK with the updated data.
            return Ok(post);
        }
        // ==================================================
        // DELETE: api/posts/1
        // ==================================================
        //
        // Handles HTTP DELETE requests.
        //
        // Used to delete an existing post.
        //
        // Example:
        // DELETE /api/posts/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            // Call the service layer to delete the post.
            var deleted = await _postService.DeletePost(id);

            // If no post was found with the given ID,
            // return HTTP 404 Not Found.
            if (!deleted)
            {
                return NotFound();
            }

            // Return HTTP 200 OK.
            return Ok();
        }
    }
}