using RareAPI_BE.Models;

namespace RareAPI_BE.Data
{
    public class CommentData
    {
        public static List<Comment> Comments =
        [

            new() {Id = 1, UserId = 1, PostId = 1, Content = "Great insights, Jon!" },
            new() {Id = 2, UserId = 1, PostId = 2, Content = "Loved the music recommendations!"},
            new() {Id = 3, UserId = 2, PostId = 3, Content = "Can't wait to visit Europe!"},
            new() {Id = 4, UserId = 3, PostId = 4, Content = "This makes me so hungry!"}

        ];
    }
}