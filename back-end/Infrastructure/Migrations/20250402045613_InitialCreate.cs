using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Robert Downey Jr." },
                    { 2, "Scarlett Johansson" },
                    { 3, "Chris Evans" },
                    { 4, "Tom Hardy" },
                    { 5, "Natalie Portman" },
                    { 6, "Leonardo DiCaprio" },
                    { 7, "Jennifer Lawrence" },
                    { 8, "Brad Pitt" },
                    { 9, "Angelina Jolie" },
                    { 10, "Keanu Reeves" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Horror" },
                    { 5, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Movie 1" },
                    { 2, 3, "Movie 2" },
                    { 3, 4, "Movie 3" },
                    { 4, 5, "Movie 4" },
                    { 5, 1, "Movie 5" },
                    { 6, 2, "Movie 6" },
                    { 7, 3, "Movie 7" },
                    { 8, 4, "Movie 8" },
                    { 9, 5, "Movie 9" },
                    { 10, 1, "Movie 10" },
                    { 11, 2, "Movie 11" },
                    { 12, 3, "Movie 12" },
                    { 13, 4, "Movie 13" },
                    { 14, 5, "Movie 14" },
                    { 15, 1, "Movie 15" },
                    { 16, 2, "Movie 16" },
                    { 17, 3, "Movie 17" },
                    { 18, 4, "Movie 18" },
                    { 19, 5, "Movie 19" },
                    { 20, 1, "Movie 20" },
                    { 21, 2, "Movie 21" },
                    { 22, 3, "Movie 22" },
                    { 23, 4, "Movie 23" },
                    { 24, 5, "Movie 24" },
                    { 25, 1, "Movie 25" },
                    { 26, 2, "Movie 26" },
                    { 27, 3, "Movie 27" },
                    { 28, 4, "Movie 28" },
                    { 29, 5, "Movie 29" },
                    { 30, 1, "Movie 30" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 6, 5 },
                    { 7, 5 },
                    { 8, 5 },
                    { 7, 6 },
                    { 8, 6 },
                    { 9, 6 },
                    { 8, 7 },
                    { 9, 7 },
                    { 10, 7 },
                    { 1, 8 },
                    { 9, 8 },
                    { 10, 8 },
                    { 1, 9 },
                    { 2, 9 },
                    { 10, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 },
                    { 2, 11 },
                    { 3, 11 },
                    { 4, 11 },
                    { 3, 12 },
                    { 4, 12 },
                    { 5, 12 },
                    { 4, 13 },
                    { 5, 13 },
                    { 6, 13 },
                    { 5, 14 },
                    { 6, 14 },
                    { 7, 14 },
                    { 6, 15 },
                    { 7, 15 },
                    { 8, 15 },
                    { 7, 16 },
                    { 8, 16 },
                    { 9, 16 },
                    { 8, 17 },
                    { 9, 17 },
                    { 10, 17 },
                    { 1, 18 },
                    { 9, 18 },
                    { 10, 18 },
                    { 1, 19 },
                    { 2, 19 },
                    { 10, 19 },
                    { 1, 20 },
                    { 2, 20 },
                    { 3, 20 },
                    { 2, 21 },
                    { 3, 21 },
                    { 4, 21 },
                    { 3, 22 },
                    { 4, 22 },
                    { 5, 22 },
                    { 4, 23 },
                    { 5, 23 },
                    { 6, 23 },
                    { 5, 24 },
                    { 6, 24 },
                    { 7, 24 },
                    { 6, 25 },
                    { 7, 25 },
                    { 8, 25 },
                    { 7, 26 },
                    { 8, 26 },
                    { 9, 26 },
                    { 8, 27 },
                    { 9, 27 },
                    { 10, 27 },
                    { 1, 28 },
                    { 9, 28 },
                    { 10, 28 },
                    { 1, 29 },
                    { 2, 29 },
                    { 10, 29 },
                    { 1, 30 },
                    { 2, 30 },
                    { 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 1, 10 },
                    { 2, 11 },
                    { 3, 12 },
                    { 4, 13 },
                    { 5, 14 },
                    { 1, 15 },
                    { 2, 16 },
                    { 3, 17 },
                    { 4, 18 },
                    { 5, 19 },
                    { 1, 20 },
                    { 2, 21 },
                    { 3, 22 },
                    { 4, 23 },
                    { 5, 24 },
                    { 1, 25 },
                    { 2, 26 },
                    { 3, 27 },
                    { 4, 28 },
                    { 5, 29 },
                    { 1, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
