using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DestinyBuildsBack.Migrations
{
    /// <inheritdoc />
    public partial class AddImgUrlToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c08bce54-b1f5-422e-ab83-9c5694142e0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec64cb0c-2777-4051-b60a-26a696cc3f3e");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Subclases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Armas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "ArmadurasExoticas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f4015ee-3a53-4c10-9c3f-9240a7ee2625", null, "Admin", "ADMIN" },
                    { "9a0a70e4-c390-49db-82c8-dcb48b4a5844", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f4015ee-3a53-4c10-9c3f-9240a7ee2625");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a0a70e4-c390-49db-82c8-dcb48b4a5844");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Subclases");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "ArmadurasExoticas");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c08bce54-b1f5-422e-ab83-9c5694142e0e", null, "Admin", "ADMIN" },
                    { "ec64cb0c-2777-4051-b60a-26a696cc3f3e", null, "User", "USER" }
                });
        }
    }
}
