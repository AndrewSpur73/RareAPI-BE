using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RareAPI_BE.Models;
using RareAPI_BE.DTOs;
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
                    return Results.NotFound("No Post Found.");
                }

                return Results.Ok(postId);
            });

            // Create a Post
            app.MapPost("/post", (RareAPI_BEDbContext db, CreatePostDTO PostDTO, IMapper mapper) => 
            {
                var newPost = mapper.Map<Post>(PostDTO);
                newPost.PostTags = PostDTO.TagIds.Select(tagId => new PostTag
                {
                    TagId = tagId
                }).ToList();

                db.Posts.Add(newPost);
                db.SaveChanges();

                return Results.Created($"/post/{newPost.Id}", newPost);
            });

        }
    }
}
