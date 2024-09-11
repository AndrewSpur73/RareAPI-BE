using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RareAPI_BE.Models;

namespace RareAPI_BE.API
{
    public class PostAPI
    {
        public static void Map(WebApplication app)
        {
            // Get All Posts + tags
            app.MapGet("/post", (RareAPI_BEDbContext db) =>
            {
                return db.Posts.Include(a => a.PostTags).ThenInclude(t => t.Tag).ToList();
            });

            // Get Single Post
            app.MapGet("/post/{id}", (RareAPI_BEDbContext db, int id) =>
            {
                var postId = db.Posts
                .Include(a => a.PostTags)
                .ThenInclude(t => t.Tag)
                .FirstOrDefault(a => a.Id == id);


                if (postId == null)
                {
                    return Results.NotFound("No Artwork Found.");
                }

                return Results.Ok(postId);
            });

        }
    }
}
