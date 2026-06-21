namespace ServerApi.Models
{
    // Namespace for data models.
    // Models define the shape of data used
    // throughout the application.
    
    public class Post
    {
        // User that owns the post
        public int UserId { get; set; }

        // Unique post identifier
        public int Id { get; set; }

        // Post title
        public string Title { get; set; } = string.Empty;

        // Post content
        public string Body { get; set; } = string.Empty;
    }
}