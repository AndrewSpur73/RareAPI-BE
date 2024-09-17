namespace RareAPI_BE.DTOs
{
    public class CreatePostDTO
    {
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public List<int>? TagIds { get; set; } = new List<int>();
    }
}
