using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DestinyBuildsBack.Migrations
{
    /// <inheritdoc />
    public partial class ControllerNameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "c08bce54-b1f5-422e-ab83-9c5694142e0e", null, "Admin", "ADMIN" },
                    { "ec64cb0c-2777-4051-b60a-26a696cc3f3e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c08bce54-b1f5-422e-ab83-9c5694142e0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec64cb0c-2777-4051-b60a-26a696cc3f3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8cd2ccf8-0f90-483d-8b44-43640ec00e1d", null, "Admin", "ADMIN" },
                    { "dcd0b19c-fceb-4b6c-accb-3929f06ac102", null, "User", "USER" }
                });
        }
    }
}
