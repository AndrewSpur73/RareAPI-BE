namespace RareAPI_BE.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public List<EditTagDTO>? EditTags { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
    }
}
