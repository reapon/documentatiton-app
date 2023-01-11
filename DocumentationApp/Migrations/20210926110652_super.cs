using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class super : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "af4c9efd-97d6-40a8-810f-1153966ae85d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-421f-86af-483d56fd7210", "ea4e2e07-7cb9-4bef-810b-f3df632d11d2", "Super Admin", "SUPER ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ade6fd6b-afa9-480c-9907-c73d272f134c", "AQAAAAEAACcQAAAAEEyQ7SZB3NhLFSqzs+kdj9V6QrfOpECfeDNqFyjpb/HDFfEQbEPx2Sywogc3xwcyOg==", "f3b04b7e-fb24-4fd7-85ae-e8e0b5b2c7c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9550d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2658295-6874-4181-a482-9dee7d106f88", "AQAAAAEAACcQAAAAEANq+IyC9fM7E6ov+Cjj7KHGL/jRyaHz1BLjWFVWPg2Nu4mgYjxH5pwLCSH981eSWw==", "fc4d6f87-296d-4916-82df-addebf6c0a60" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-421f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9550d048cdb9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-421f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9550d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-421f-86af-483d56fd7210");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9550d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bd6c517-8857-4bc7-9b88-28ac389e691e", "AQAAAAEAACcQAAAAEJCz22nDt5Z3jnlzT7Cg5ubtF9v1KXasChzU5uatYTkKOofqAPePboJralNIeuo2IQ==", "e6a4d5ec-d4ad-4352-95ba-fa920b2a5c91" });
        }
    }
}
