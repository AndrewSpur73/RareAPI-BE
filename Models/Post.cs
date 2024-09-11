namespace RareAPI_BE.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<PostTag>? PostTags { get; set; }
        public User? User { get; set; }
        
    }
}
