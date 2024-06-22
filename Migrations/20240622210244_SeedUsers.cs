using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegexMaster.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "SignUpDate" },
                values: new object[,]
                {
                    { 1, "user1@example.com", "password1", new DateTime(2024, 6, 22, 23, 2, 42, 876, DateTimeKind.Local).AddTicks(3779) },
                    { 2, "user2@example.com", "password2", new DateTime(2024, 6, 22, 23, 2, 42, 876, DateTimeKind.Local).AddTicks(3832) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
