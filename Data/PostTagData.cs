using RareAPI_BE.Models;

namespace RareAPI_BE.Data
{
    public class PostTagData
    {
        public static List<PostTag> PostTags =
    [

        new() {Id = 1, PostId = 1, TagId = 1},
        new() {Id = 5, PostId = 1, TagId = 3},
        new() {Id = 2, PostId = 2, TagId = 2},
        new() {Id = 6, PostId = 2, TagId = 6},
        new() {Id = 3, PostId = 3, TagId = 4},
        new() {Id = 4, PostId = 4, TagId = 5}

    ];
    }
}
