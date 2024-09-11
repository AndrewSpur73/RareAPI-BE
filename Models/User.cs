namespace RareAPI_BE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Bio {  get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? FirebaseId { get; set; }
        public List<Post>? Post {  get; set; }
        public List<Comment>? Comment { get; set; }

    }
}
