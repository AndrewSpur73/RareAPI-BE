using RareAPI_BE.Models;
using Microsoft.EntityFrameworkCore;
using RareAPI_BE.DTOs;
using AutoMapper;

namespace RareAPI_BE.API
{
    public class CommentAPI
    {
        public static void Map(WebApplication app)
        {
            //Create a comment
            app.MapPost("/comments", (RareAPI_BEDbContext db, IMapper mapper, CreateCommentDTO newCommentDTO) =>
            {

                var newComment = mapper.Map<Comment>(newCommentDTO);

                try
                {
                    db.Comments.Add(newComment);
                    db.SaveChanges();
                    return Results.Created($"/posts/{newComment.Id}", newComment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Results.BadRequest("an error occured trying to add a new comment to the database");
                }
            });

            //Delete a comment
            app.MapDelete("/comments/{id}", (RareAPI_BEDbContext db, int id) =>
                {

                    var comment = db.Comments.FirstOrDefault(c => c.Id == id);

                    if (comment == null)
                    {
                        return Results.NotFound("comment is null");
                    }

                    db.Comments.Remove(comment);
                    db.SaveChanges();
                    return Results.Ok("comment deleted");

                });

            //Get all of a Post's comments
            app.MapGet("/comments/posts/{id}", async (RareAPI_BEDbContext db, int id) =>
            {
                var comments = await db.Comments.Where(c => c.PostId == id).Include(c =>c.User).ToListAsync();

                if (comments == null)
                {
                    return Results.NotFound("comment is null");
                }

                return Results.Ok(comments);

            });

            //Edit A Comment
            app.MapPatch("/comments/{id}", (RareAPI_BEDbContext db, int id, EditCommentDTO editCommentDTO, IMapper mapper) =>
            {

                var commentToEdit = db.Comments.FirstOrDefault(c => c.Id == id);

                if (commentToEdit == null)
                {
                    return Results.NotFound("Comment not found");
                }

                mapper.Map(editCommentDTO, commentToEdit);

                try
                {
                    db.SaveChanges();
                    return Results.Ok(commentToEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Results.BadRequest("An error occurred while updating the comment.");
                }


            });
        }
    }
}
