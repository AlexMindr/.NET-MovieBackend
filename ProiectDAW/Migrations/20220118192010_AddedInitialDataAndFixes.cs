using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDAW.Migrations
{
    public partial class AddedInitialDataAndFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataBaseModels");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "Roles",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TmdbId",
                schema: "dbo",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                schema: "dbo",
                table: "MovieGenres",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "Genres",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 28, "Action" },
                    { 37, "Western" },
                    { 10752, "War" },
                    { 53, "Thriller" },
                    { 10770, "TV Movie" },
                    { 878, "Science Fiction" },
                    { 10749, "Romance" },
                    { 9648, "Mystery" },
                    { 10402, "Music" },
                    { 27, "Horror" },
                    { 14, "Fantasy" },
                    { 10751, "Family" },
                    { 18, "Drama" },
                    { 99, "Documentary" },
                    { 80, "Crime" },
                    { 35, "Comedy" },
                    { 16, "Animation" },
                    { 12, "Adventure" },
                    { 36, "History" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 878);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9648);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10402);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10749);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10751);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10752);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10770);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TmdbId",
                schema: "dbo",
                table: "Movies");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                schema: "dbo",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                schema: "dbo",
                table: "MovieGenres",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "DataBaseModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBaseModels", x => x.Id);
                });
        }
    }
}
