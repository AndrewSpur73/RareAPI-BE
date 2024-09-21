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
                    Uid = table.Column<string>(type: "text", nullable: true)
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
                    UserId = table.Column<int>(type: "integer", nullable: true),
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
                        principalColumn: "Id");
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
                columns: new[] { "Id", "Bio", "Email", "ImageUrl", "Uid", "UserName" },
                values: new object[,]
                {
                    { 1, "The Pilsbury doughboy ain't got shit on me", "DoughMon@gmail.com", "https://images.playground.com/7344181b53c14f018042ea2a7ec1cc3e.jpeg", "", "JonDough" },
                    { 2, "If bitches get stitches, what do good boys get?", "Mrthincrisp@gmail.com", "", "xkZcuwDM5hXjHreMiKgs9AHVlcX2", "Mrthincrisp" },
                    { 3, "Music is my life", "ross.morgan933@gmail.com", "", "foSJhCcjadNP0TsmghEFzOt2GgX2", "RossMorgan" },
                    { 4, "Traveler, blogger, coffee lover", "aspurlock@coding.com", "", "Firebase_Key", "AndrewSpurlock" },
                    { 5, "Tech geek with a passion for AI", "ChrisTechy@gmail.com", "https://www.southernliving.com/thmb/cxeGxYshY26hzmi5TToGS3oTraQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Lowes-Exterior-2000-9577c2caf665407083589a6cb2747301.jpg", "", "ChrisLowe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "ImageUrl", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Tech trends are rapidly shaping the future, with advancements in artificial intelligence (AI), blockchain, and quantum computing leading the way. AI continues to transform industries through automation, machine learning, and natural language processing, improving everything from customer service to medical diagnostics. Blockchain is disrupting finance and cybersecurity with decentralized systems that offer transparency and security, while quantum computing promises to revolutionize problem-solving in fields like cryptography and material science. The rise of 5G is also enabling faster, more connected networks, powering innovations like the Internet of Things (IoT) and smart cities. Additionally, advancements in virtual and augmented reality (VR/AR) are redefining how we experience entertainment, work, and education, creating immersive digital environments that are more integrated into daily life. These trends collectively push the boundaries of what's possible, signaling a tech-driven future with limitless potential.", "https://thehill.com/wp-content/uploads/sites/2/2018/05/robot_051018gn.jpg?w=960&h=540&crop=1", "Tech Trends 2024", 1 },
                    { 2, "The Northern Pines’ latest indie release, Wanderlust Echoes, is a refreshing blend of ethereal melodies and introspective lyrics that feels like wandering into a dream. With fragile yet resilient vocals from lead singer Jess Meyers, the album’s emotional rawness draws you in from the first track, \"Clouded Horizons.\" Songs like \"Midnight Runaway\" and \"Saltwater Skies\" showcase the band’s layered instrumentation and intricate attention to detail, weaving themes of self-discovery and escapism into each note. The standout track, \"Fading Trails,\" offers an addictive bassline and atmospheric synths, while \"Silver Shoreline\" provides a quieter, acoustic-driven moment of reflection. Though Wanderlust Echoes doesn’t stray far from the band’s earlier work, it feels like a natural progression, offering a beautifully human experience perfect for introspective moments or long drives. This is indie music at its finest.", "https://qph.cf2.quoracdn.net/main-qimg-7363ad9a5fb42cc0d1b1b35dd92135ac", "Best Indie Albums", 2 },
                    { 3, "Exploring Europe is a journey through diverse cultures, rich history, and breathtaking landscapes that can feel like stepping into a living museum. From the bustling streets of Paris to the quiet canals of Venice, every city tells its own story through its architecture, cuisine, and local traditions. Whether you're hiking the Swiss Alps, relaxing on the beaches of Greece, or wandering through medieval castles in Germany, Europe offers something for every type of traveler. The continent’s seamless transportation system makes it easy to hop between countries, allowing you to experience the vibrant nightlife in Barcelona one day and the historical charm of Prague the next. Each destination offers its own unique flavor, yet there's a shared sense of history and connection that ties it all together, making Europe a dream destination for anyone with a thirst for adventure and discovery.", "https://i.cbc.ca/1.6729582.1674911696!/cumulusImage/httpImage/image.jpg_gen/derivatives/16x9_780/kitchener-homeless-encampment-victoria-and-weber-streets.jpg", "Exploring Europe", 3 },
                    { 4, "Gourmet Delights is an innovative culinary creation that takes indulgence to a whole new level with its unique blend of exotic ingredients and unexpected flavors. Each dish in the Gourmet Delights line is meticulously crafted by expert chefs, combining rare spices from remote corners of the globe with organic, locally-sourced produce. The result is a menu that tantalizes the taste buds with surprising combinations like truffle-infused dragon fruit, caramelized cactus blossoms, and saffron-dusted seaweed crisps. Perfect for food enthusiasts seeking a luxurious dining experience, Gourmet Delights promises a flavor journey that pushes the boundaries of traditional cuisine, offering a mix of savory, sweet, and umami that’s truly unforgettable.", "https://gaianism.org/wp-content/uploads/2022/02/soylent-green-new-packaging1.png", "Gourmet Delights", 4 }
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
