// Imports the Post model because this service
// works with Post objects.
using ServerApi.Models;

namespace ServerApi.Services
{
    // Namespace for business logic classes.
    // Controllers call services instead of directly
    // accessing data.
    public class PostService
    {
        // In-memory storage.
        // Static means shared across all instances
        // of PostService while the application runs.
        private static readonly List<Post> AllPosts = new();

        // CREATE
        // Adds a new post.
        public Task CreatePost(Post item)
        {
            AllPosts.Add(item);

            // Returns a completed async task.
            return Task.CompletedTask;
        }

        // UPDATE
        // Finds a post and updates its values.
        public Task<Post?> UpdatePost(int id, Post item)
        {
            var post = AllPosts.FirstOrDefault(x => x.Id == id);

            if (post != null)
            {
                post.Title = item.Title;
                post.Body = item.Body;
                post.UserId = item.UserId;
            }

            return Task.FromResult(post);
        }

        // READ ONE
        // Finds a single post by ID.
        public Task<Post?> GetPost(int id)
        {
            var post = AllPosts.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(post);
        }

        // READ ALL
        // Returns all posts.
        public Task<List<Post>> GetAllPosts()
        {
            return Task.FromResult(AllPosts);
        }

        // DELETE
        // Removes a post by ID.
        public Task<bool> DeletePost(int id)
        {
            var post = AllPosts.FirstOrDefault(x => x.Id == id);

            if (post != null)
            {
                AllPosts.Remove(post);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}