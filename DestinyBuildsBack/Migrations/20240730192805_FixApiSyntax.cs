using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DestinyBuildsBack.Migrations
{
    /// <inheritdoc />
    public partial class FixApiSyntax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "667c4f1f-51ff-4398-9748-7998b2dda846");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c15ed7a-14f7-4d72-8f5a-46ad78c7b5b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8cd2ccf8-0f90-483d-8b44-43640ec00e1d", null, "Admin", "ADMIN" },
                    { "dcd0b19c-fceb-4b6c-accb-3929f06ac102", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cd2ccf8-0f90-483d-8b44-43640ec00e1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcd0b19c-fceb-4b6c-accb-3929f06ac102");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "667c4f1f-51ff-4398-9748-7998b2dda846", null, "User", "USER" },
                    { "6c15ed7a-14f7-4d72-8f5a-46ad78c7b5b7", null, "Admin", "ADMIN" }
                });
        }
    }
}
