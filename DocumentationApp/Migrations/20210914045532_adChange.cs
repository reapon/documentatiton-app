using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class adChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contents_MenuID",
                table: "Contents");

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7df45106-917b-4e6d-8dcf-889b816db6a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70c858ce-ce36-4430-8078-127bf3074446", "AQAAAAEAACcQAAAAENlt2Uy/H69uf/6yPHQiml6Xj8lpIzpiP02+f27dYPLTDcE2G3iKcrdgSG88YniFbg==", "e6b71a95-bcca-417f-a833-d32bbb7a916b" });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_MenuID",
                table: "Contents",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contents_MenuID",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                table: "Contents");

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
                name: "IX_Contents_MenuID",
                table: "Contents",
                column: "MenuID",
                unique: true);
        }
    }
}
