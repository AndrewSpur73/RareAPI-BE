namespace RareAPI_BE.DTOs
{
    public class CreateCommentDTO
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? Content { get; set; }
    }
}
