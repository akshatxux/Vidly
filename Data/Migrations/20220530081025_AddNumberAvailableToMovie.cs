using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    public partial class AddNumberAvailableToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberAvailable",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"UPDATE Movies SET NumberAvailable = NumberInStock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberAvailable",
                table: "Movies");
        }
    }
}
