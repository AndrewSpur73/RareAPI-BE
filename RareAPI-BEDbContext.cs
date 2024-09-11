using Microsoft.EntityFrameworkCore;
using RareAPI_BE.Models;
using RareAPI_BE.Data;

namespace RareAPI_BE
{
    public class RareAPI_BEDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<User> Users { get; set; }

        public RareAPI_BEDbContext(DbContextOptions<RareAPI_BEDbContext> context): base(context)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Seed data for the application
            modelBuilder.Entity<Comment>().HasData(CommentData.Comments);
            modelBuilder.Entity<Tag>().HasData(TagData.Tags);
            modelBuilder.Entity<PostTag>().HasData(PostTagData.PostTags);
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<Post>().HasData(PostData.Posts);

            //relationship between Post and Comments, When a Post is delted any related Comments will be deleted as well. 
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            //Post and PostTag relationship
            modelBuilder.Entity<Post>()
                .HasMany(p => p.PostTags)
                .WithOne(pt => pt.Post)
                .HasForeignKey(pt => pt.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostTag>()
                  .HasOne(pt => pt.Tag)
                  .WithMany(t => t.PostTags)
                  .HasForeignKey(pt => pt.TagId)
                  .OnDelete(DeleteBehavior.Restrict);





        }

    }
}
