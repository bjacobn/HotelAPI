using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a41edac-f6d8-4513-96d2-72ef00b07de1", "87f8e2f1-c023-4aca-bc7e-c49d4075a1f3", "Administrator", "ADMINISTRATOR" },
                    { "61ccabb4-0045-4abc-9134-44ac28bf93b0", "49182a5f-c487-4caa-a9c6-b343724a7cc4", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a41edac-f6d8-4513-96d2-72ef00b07de1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61ccabb4-0045-4abc-9134-44ac28bf93b0");
        }
    }
}
