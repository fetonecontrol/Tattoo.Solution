using Microsoft.EntityFrameworkCore.Migrations;

namespace Tattoo.Migrations
{
    public partial class AddJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistStyleId",
                table: "ArtistClientStyles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistStyleId",
                table: "ArtistClientStyles",
                nullable: false,
                defaultValue: 0);
        }
    }
}
