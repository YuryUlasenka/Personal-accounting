using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalAccountingBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserAndRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0d313fd-db09-4746-bcb4-0b8ddc2365ec", "d9b45cab-2f08-43ed-973f-948488fbb6c4", "Administrator", "ADMINISTRATOR" },
                    { "e811b5c0-f46c-4a5f-b59f-8c3e9d3ccc3f", "d993cef9-be7e-49a5-a1f2-b3b0814dc368", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a966b9a5-41f9-4a4d-b994-4b5b0fbb3b97", 0, "658b903d-8846-4a57-a859-f2d22a7faeb5", "admin@test.com", false, "Admin", "Adminych", false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAEAACcQAAAAELGWkQ2iR+rGgMUuQceLJbO94I4nQJVxo8+73DmT6CKKJU22NMPBTB2HwOL5vWOjIg==", null, false, "899599a3-2608-4c57-97b4-6d0addd9e7af", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a0d313fd-db09-4746-bcb4-0b8ddc2365ec", "a966b9a5-41f9-4a4d-b994-4b5b0fbb3b97" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e811b5c0-f46c-4a5f-b59f-8c3e9d3ccc3f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a0d313fd-db09-4746-bcb4-0b8ddc2365ec", "a966b9a5-41f9-4a4d-b994-4b5b0fbb3b97" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0d313fd-db09-4746-bcb4-0b8ddc2365ec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a966b9a5-41f9-4a4d-b994-4b5b0fbb3b97");
        }
    }
}
