using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateDemo.Migrations
{
    public partial class seedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7dee10a-2e43-4678-abe9-070b46c87258", "5b3c1fe2-f2d3-403a-a633-6410b11f39df", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "576f4413-7a64-48d6-a630-3415af2beb97", "5607c70c-d617-4045-b96c-d8ffcc1d3a4e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "576f4413-7a64-48d6-a630-3415af2beb97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7dee10a-2e43-4678-abe9-070b46c87258");
        }
    }
}
