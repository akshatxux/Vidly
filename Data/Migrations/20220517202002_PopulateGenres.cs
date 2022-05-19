using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Drama" },
                    { "2", "Comedy" },
                    { "3", "Thriller" },
                    { "4", "Family" },
                    { "5", "Action" },
                    { "6", "Horror" },
                    { "7", "Romance" },
                    { "8", "Science Fiction" },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
