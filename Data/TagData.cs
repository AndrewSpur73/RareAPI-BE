using RareAPI_BE.Models;

namespace RareAPI_BE.Data
{
    public class TagData { 

       public static List<Tag> Tags =
       [

        new() { Id = 1, Name = "Technology"},
        new() { Id = 2, Name = "Music"},
        new() { Id = 3, Name = "Lifestyle" },
        new() { Id = 4, Name = "Travel" },
        new() { Id = 5, Name = "Food" },
        new() { Id = 6, Name = "Health" }

       ];
    }
};