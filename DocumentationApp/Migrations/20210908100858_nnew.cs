using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class nnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarkAsReads",
                columns: table => new
                {
                    MarkAsReadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkAsReads", x => x.MarkAsReadID);
                    table.ForeignKey(
                        name: "FK_MarkAsReads_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarkAsReads");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e20fb448-7f2b-4296-84bc-4036a978e2f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a307b49-8d3b-4427-8c4c-95389276e9de", "AQAAAAEAACcQAAAAEJdOMlkTBaNjlg408giKbqE3/t2qpVw+xZxdc+e4glQD821hyQCONGSPgXaQG6Gfiw==", "21fc4505-3b99-4008-b9f5-325025299b09" });
        }
    }
}
