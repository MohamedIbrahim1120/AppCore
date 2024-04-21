using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class usersRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "430543b6-0fa2-4328-a51b-ffc2db6b7689", "511342a4-ee15-4960-ac2f-8e3acbba0f69", "Admin", "admin" },
                    { "53e8f598-f7c7-4511-9fb6-b7f919feafde", "3b31b8ea-7346-4ff7-9327-a9747eabc63e", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "430543b6-0fa2-4328-a51b-ffc2db6b7689");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53e8f598-f7c7-4511-9fb6-b7f919feafde");
        }
    }
}
