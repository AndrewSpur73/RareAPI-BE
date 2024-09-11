using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RareAPI_BE.Models;

namespace RareAPI_BE.API
{
    public class PostAPI
    {
        public static void Map(WebApplication app)
        {
            // Get All Artwork + tags
            app.MapGet("/post", (RareAPI_BEDbContext db) =>
            {
                return db.Posts.Include(a => a.PostTags).ThenInclude(t => t.Tag).ToList();
            });

        }
    }
}
