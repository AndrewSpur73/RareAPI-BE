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
            app.MapGet("/post", async (RareAPI_BEDbContext db ) =>
            {

                var post = await db.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Include(p => p.PostTags).ThenInclude(sg => sg.Tag)
                .ToListAsync();

             return Results.Ok(post);

            });

            // Get Single Post
            app.MapGet("/post/{id}", (RareAPI_BEDbContext db, int id) =>
            {
                var postId = db.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
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
            app.MapPost("/post", (RareAPI_BEDbContext db, CreatePostDTO postDTO, IMapper mapper) => 
            {
                var newPost = mapper.Map<Post>(postDTO);
                newPost.PostTags = postDTO.TagIds?.Select(tagId => new PostTag
                {
                    TagId = tagId
                }).ToList();

                db.Posts.Add(newPost);
                db.SaveChanges();

                return Results.Created($"/post/{newPost.Id}", newPost);
            });

            // Update a Post
            app.MapPut("/post/{id}", (RareAPI_BEDbContext db, IMapper mapper, int id, UpdatePostDTO postDTO) =>
            {

                var postToUpdate = db.Posts.Include(p => p.PostTags).FirstOrDefault(p => p.Id == id);
                if (postToUpdate == null)
                {
                    return Results.NotFound("Post not found");
                }

                mapper.Map(postDTO, postToUpdate);
                var currentTags = postToUpdate.PostTags.ToList();
                var incomingTags = postDTO.TagIds?.ToList() ?? new List<int>();
                foreach (int tagId in incomingTags)
                {
                    if (!currentTags.Any(t => t.TagId == tagId))
                    {
                        postToUpdate.PostTags.Add(new PostTag
                        {
                            TagId = tagId,
                            PostId = postToUpdate.Id
                        });
                    }
                }
                foreach (var postTag in currentTags) 
                { 
                    if (!incomingTags.Contains(postTag.TagId))
                    {
                        postToUpdate.PostTags.Remove(postTag);
                    }
                }
                try
                {
                    db.SaveChanges();
                    return Results.Ok(postToUpdate);
                }

                catch (DbUpdateException)
                {
                    return Results.BadRequest("Error occurred updating post");
                }


            });

            // Delete a Post
            app.MapDelete("/post/{id}", (RareAPI_BEDbContext db, int id) =>
            {
                var postToDelete = db.Posts.FirstOrDefault(s => s.Id == id);

                if (postToDelete == null)
                {
                    return Results.NotFound("No post with matching id");
                }

                db.Posts.Remove(postToDelete);
                db.SaveChanges();
                return Results.Ok("Post deleted");
            });

        }
    }
}
