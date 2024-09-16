using RareAPI_BE.Models;

namespace RareAPI_BE.DTOs
{
    public class UpdatePostDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public List<int>? TagIds { get; set; }
    }
}
