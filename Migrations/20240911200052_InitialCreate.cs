using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RareAPI_BE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    FirebaseId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Technology" },
                    { 2, "Music" },
                    { 3, "Lifestyle" },
                    { 4, "Travel" },
                    { 5, "Food" },
                    { 6, "Health" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Email", "FirebaseId", "ImageUrl", "UserName" },
                values: new object[,]
                {
                    { 1, "The Pilsbury doughboy ain't got shit on me", "DoughMon@gmail.com", "", "https://images.playground.com/7344181b53c14f018042ea2a7ec1cc3e.jpeg", "JonDough" },
                    { 2, "If bitches get stitches, what do good boys get?", "Mrthincrisp@gmail.com", "xkZcuwDM5hXjHreMiKgs9AHVlcX2", "", "Mrthincrisp" },
                    { 3, "Music is my life", "ross.morgan933@gmail.com", "foSJhCcjadNP0TsmghEFzOt2GgX2", "", "RossMorgan" },
                    { 4, "Traveler, blogger, coffee lover", "andrewspurlock@rocketmail.com", "EuuoQaFhV2Wu5hjPA3DrS8ASRoC3", "", "AndrewSpurlock" },
                    { 5, "Tech geek with a passion for AI", "ChrisTechy@gmail.com", "", "https://www.southernliving.com/thmb/cxeGxYshY26hzmi5TToGS3oTraQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Lowes-Exterior-2000-9577c2caf665407083589a6cb2747301.jpg", "ChrisLowe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "ImageUrl", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "A deep dive into upcoming technology trends.", "https://thehill.com/wp-content/uploads/sites/2/2018/05/robot_051018gn.jpg?w=960&h=540&crop=1", "Tech Trends 2024", 1 },
                    { 2, "Top 10 indie albums you must listen to in 2024.", "https://preview.redd.it/whats-the-weirdest-album-cover-youve-ever-seen-v0-l2sre3xg799b1.jpeg?width=1242&format=pjpg&auto=webp&s=d7562fd2e4fb7cb3ce5c850f64754b373f6be07c", "Best Indie Albums", 2 },
                    { 3, "A guide to budget-friendly travels across Europe.", "https://i.cbc.ca/1.6729582.1674911696!/cumulusImage/httpImage/image.jpg_gen/derivatives/16x9_780/kitchener-homeless-encampment-victoria-and-weber-streets.jpg", "Exploring Europe", 3 },
                    { 4, "Best new food product!", "https://gaianism.org/wp-content/uploads/2022/02/soylent-green-new-packaging1.png", "Gourmet Delights", 4 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Great insights, Jon!", 1, 1 },
                    { 2, "Loved the music recommendations!", 2, 1 },
                    { 3, "Can't wait to visit Europe!", 3, 2 },
                    { 4, "This makes me so hungry!", 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "Id", "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 4 },
                    { 4, 4, 5 },
                    { 5, 1, 3 },
                    { 6, 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
