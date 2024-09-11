using RareAPI_BE.Models;

namespace RareAPI_BE.Data
{
    public class PostData
    {
        public static List<Post> Posts = new()
        {

            new() {Id = 1, UserId = 1, Title = "Tech Trends 2024", Content = "A deep dive into upcoming technology trends.", ImageUrl = "https://thehill.com/wp-content/uploads/sites/2/2018/05/robot_051018gn.jpg?w=960&h=540&crop=1"},
            new() {Id = 2, UserId = 2, Title = "Best Indie Albums", Content = "Top 10 indie albums you must listen to in 2024.", ImageUrl = "https://preview.redd.it/whats-the-weirdest-album-cover-youve-ever-seen-v0-l2sre3xg799b1.jpeg?width=1242&format=pjpg&auto=webp&s=d7562fd2e4fb7cb3ce5c850f64754b373f6be07c"},
            new() {Id = 3, UserId = 3, Title = "Exploring Europe", Content = "A guide to budget-friendly travels across Europe.", ImageUrl = "https://i.cbc.ca/1.6729582.1674911696!/cumulusImage/httpImage/image.jpg_gen/derivatives/16x9_780/kitchener-homeless-encampment-victoria-and-weber-streets.jpg"},
            new() {Id = 4, UserId = 4, Title = "Gourmet Delights", Content = "Best new food product!", ImageUrl = "https://gaianism.org/wp-content/uploads/2022/02/soylent-green-new-packaging1.png"}

        };
    }
}
