using RareAPI_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace RareAPI_BE.API
{
    public class CommentAPI
    {
        public static void Map(WebApplication app)
        {
            //Create a comment
            //Delete a comment
            //Get all of a Post's comments
            app.MapGet("/posts/{id}", async (RareAPI_BEDbContext db, int id) =>
            {
                var comments = await db.Comments.Where(c => c.PostId == id).ToListAsync();

                if (comments == null)
                {
                    return Results.NotFound("comment is null");
                }

                return Results.Ok(comments);

            });
            //Edit A Comment

        }
    }
}
