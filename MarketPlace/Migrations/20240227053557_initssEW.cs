using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class initssEW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c2301bb-daa0-4345-8558-e32ef98334b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33a709a0-b6a8-4c83-ba40-4a31047291a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f45bb86-aec4-47df-9fa3-cdf083243e97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f421eb-772d-4059-b40b-4224d7f132cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "486d4d9e-c70d-4f5f-872a-ee6ee3e5be6d", null, "ADMIN", "ADMIN" },
                    { "b8cd844b-1352-4c13-8d8e-cda6cef4b13c", null, "CUSTOMER", "CUSTOMER" },
                    { "d5e2c9fb-2bb6-47f2-acd9-47572fcd5746", null, "MANAGER", "MANAGER" },
                    { "f572e534-8699-485b-b8e6-64a58c505ad8", null, "USER", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "486d4d9e-c70d-4f5f-872a-ee6ee3e5be6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8cd844b-1352-4c13-8d8e-cda6cef4b13c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5e2c9fb-2bb6-47f2-acd9-47572fcd5746");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f572e534-8699-485b-b8e6-64a58c505ad8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c2301bb-daa0-4345-8558-e32ef98334b5", null, "MANAGER", "MANAGER" },
                    { "33a709a0-b6a8-4c83-ba40-4a31047291a6", null, "CUSTOMER", "CUSTOMER" },
                    { "5f45bb86-aec4-47df-9fa3-cdf083243e97", null, "USER", "USER" },
                    { "98f421eb-772d-4059-b40b-4224d7f132cd", null, "ADMIN", "ADMIN" }
                });
        }
    }
}
