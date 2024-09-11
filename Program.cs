using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using RareAPI_BE.API;


namespace RareAPI_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowCredentials();
                    });
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program)); //Adds AutoMapper to the build

            // allows passing datetimes without time zone data 
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // allows our api endpoints to access the database through Entity Framework Core
            builder.Services.AddNpgsql<RareAPI_BEDbContext>(builder.Configuration["RareAPI_BEDbConnectionString"]);

            // Set the JSON serializer options 
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });


            var app = builder.Build();

            app.UseCors();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            CommentAPI.Map(app);
            UserAPI.Map(app);

            app.Run();
        }
    }
}
