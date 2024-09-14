using Microsoft.EntityFrameworkCore;
using RareAPI_BE.Models;

namespace RareAPI_BE.API

{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            //LOGIN
            app.MapGet("/checkuser/{uid}", (RareAPI_BEDbContext db, string uid) =>
            {
                var authUser = db.Users.Where(u => u.Uid == uid).FirstOrDefault();
                if (authUser == null)
                {
                    return Results.StatusCode(204);
                }
                return Results.Ok(authUser);
            });

            //Users
            app.MapGet("/users", (RareAPI_BEDbContext db) =>
            {
                return db.Users.ToList();
            });


            //Register User
            app.MapPost("/users", (RareAPI_BEDbContext db, User userInfo) =>
            {
                db.Users.Add(userInfo);
                db.SaveChanges();
                return Results.Created($"/users/{userInfo.Id}", userInfo);
            });

            //Check User
            app.MapGet("/users/{id}", (RareAPI_BEDbContext db, int id) =>
            {
                User user = db.Users.SingleOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });

            //Get User Details
            app.MapGet("/users/details/{uid}", (RareAPI_BEDbContext db, string uid) =>
            {

                User user = db.Users.SingleOrDefault(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(user);
            });
        }
    }
}
