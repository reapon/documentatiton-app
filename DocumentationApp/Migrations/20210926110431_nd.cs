using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f6f2fad0-6f09-4a3e-a24b-77448469ee1c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "570ad031-47b6-4851-82bb-dd398ec70fff", "AQAAAAEAACcQAAAAEEtf35M4lQGctF4TVcb/RMgEMi+pO/JE0XRbbAwcgGbRyRM6q2zc2UQRVNEksPxy+w==", "7a1b17e3-227f-492b-b9b1-7e5814fb352f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9550d048cdb9", 0, "0bd6c517-8857-4bc7-9b88-28ac389e691e", null, true, false, null, null, "gtradmin@gmail.com", "AQAAAAEAACcQAAAAEJCz22nDt5Z3jnlzT7Cg5ubtF9v1KXasChzU5uatYTkKOofqAPePboJralNIeuo2IQ==", null, false, "e6a4d5ec-d4ad-4352-95ba-fa920b2a5c91", false, "gtradmin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9550d048cdb9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4fbadee2-4eb5-436d-8ccc-4349f33e4831");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ea125b3-27a0-423f-9ba2-f96928b0ac8d", "AQAAAAEAACcQAAAAEFAEQ9RRQTY/IA8MTzBVKqHi+Aghl5JZAhVcvtt0/E+E0qCjMCVq95nV1JXbjFqLhw==", "7d4fd565-88f1-4522-999e-399fd99681b7" });
        }
    }
}
