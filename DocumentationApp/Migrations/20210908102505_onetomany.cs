using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarkAsReads_MenuID",
                table: "MarkAsReads");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9e988f12-fef9-4149-bf2a-24adb364b020");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bc5880d-1455-4af6-8580-943e5c284006", "AQAAAAEAACcQAAAAEOiyeGqhXN+FsZ+nm8WxcIxof7xF69WoLBY4J7pxkxR2Z6ZiKkEHSeN+E4aG7BZtdQ==", "b3dd8ef9-67f2-4a2d-9839-5b242f9fdff2" });

            migrationBuilder.CreateIndex(
                name: "IX_MarkAsReads_MenuID",
                table: "MarkAsReads",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarkAsReads_MenuID",
                table: "MarkAsReads");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c1feb39a-ba04-480e-8e12-c5a1269f3bae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d9f448b-f0fd-4b8e-8aeb-02ebbd653fee", "AQAAAAEAACcQAAAAEOJlZw1DwHbr63o3mxnUxXmkKeoxvCnhPmKjajgtB9hvzkTESuXhTKNIezB1S9F46g==", "93409bc0-6912-4c4a-a73b-179d435aa8c9" });

            migrationBuilder.CreateIndex(
                name: "IX_MarkAsReads_MenuID",
                table: "MarkAsReads",
                column: "MenuID",
                unique: true);
        }
    }
}
