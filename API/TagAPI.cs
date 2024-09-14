using RareAPI_BE.Models;
using Microsoft.EntityFrameworkCore;
using RareAPI_BE.DTOs;
using RareAPI_BE.Mapper;
using AutoMapper;

namespace RareAPI_BE.API
{
    public class TagAPI
    {        
        public static void Map(WebApplication app)
        {
            //Get all Tags
            app.MapGet("/tags", (RareAPI_BEDbContext db) =>
            {

                return Results.Ok(db.Tags);

            });

            //Create a Tag
            app.MapPost("/tags", (RareAPI_BEDbContext db, IMapper mapper, CreateTagDTO newTagDTO) =>
            {

                var newTag = mapper.Map<Tag>(newTagDTO);
                try
                {
                    db.Tags.Add(newTag);
                    db.SaveChanges();
                    return Results.Created($"/tags/{newTag.Id}", newTag);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Results.BadRequest("an error occured trying to add a new tag to the database, check payload format.");
                }

            });

            //Delete a Tag
            app.MapDelete("/tags/{id}", (RareAPI_BEDbContext db, int id) =>
            {

                var tagToDelete = db.Tags.FirstOrDefault(t => t.Id == id);

                if (tagToDelete == null)
                {
                    Results.NotFound("genre id not found");
                }

                var postTagEntryToDelete = db.PostTags.Where(pt => pt.TagId == id).ToList();

                db.PostTags.RemoveRange(postTagEntryToDelete);
                db.Tags.Remove(tagToDelete);
                db.SaveChanges();
                return Results.Ok("Tag, and PostTag(s) deleted");

            });

            //Edit a Tag
            app.MapPatch("/tags/{id}", (RareAPI_BEDbContext db, int id, IMapper mapper, EditTagDTO updatedTagDTO) =>
            {

                var tagToEdit = db.Tags.FirstOrDefault(t =>t.Id == id);

                if (tagToEdit == null)
                {
                    Results.NotFound("genre id not found");
                }

                mapper.Map(updatedTagDTO, tagToEdit);

                try
                {
                    db.SaveChanges();
                    return Results.Ok(tagToEdit);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("An error occured trying to update the tag in the Database, check payload format");
                }

            });
        }
    }
}
