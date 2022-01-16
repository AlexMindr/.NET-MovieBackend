using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDAW.Migrations
{
    public partial class UpdatedMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                schema: "dbo",
                table: "Movies",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                schema: "dbo",
                table: "Movies");
        }
    }
}
