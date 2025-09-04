using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Infra.Migrations
{
    /// <inheritdoc />
    public partial class seedingAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "UserRole" },
                values: new object[] { 1, new DateTime(2025, 9, 4, 17, 53, 22, 758, DateTimeKind.Local).AddTicks(5886), "Admin@gmail.com", "Admin", "Adminian", "$2a$11$Lbq4IcZWCQdEhf3WKBr2fu6ezbwESU3TOTWgoN1w6LDfFrp.YmFli", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "UserRole" },
                values: new object[] { 2, new DateTime(2025, 9, 4, 17, 49, 50, 473, DateTimeKind.Local).AddTicks(9921), "Admin@gmail.com", "Admin", "Adminian", "$2a$11$uZJqwmMP2XdPkDZVqFSS9ezMOFiEk9ysnjnvvQ8c52O7M4F8ZKsVC", 1 });
        }
    }
}
