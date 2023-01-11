using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class Restricted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRestricted",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-421f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5caa2a0f-5a31-4d50-aa1b-9485e4630fbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "531acfde-089e-47e1-b798-0294d7879af6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67050276-933b-4c5e-9dc2-1a04246db20d", "AQAAAAEAACcQAAAAEDIhyMlDQKDhV9xrB767jmFqusw1CswKrcrFGt2QGOni0mgRcgFfvV7CITS/jKTvXg==", "7c2498d4-fa36-4935-b0ea-22e3b260858d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9550d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bfa2d22-3125-45e4-9e87-f54f5c3958e9", "AQAAAAEAACcQAAAAECukUtB80TmjMV6wGe4+Q3awSg5Hecvd6d8PsmKiRC7WJEzE17DEIyzCfBht71VQGg==", "de5e8c47-8720-46eb-95cf-21233cebce8a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRestricted",
                table: "Menus");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-421f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ea4e2e07-7cb9-4bef-810b-f3df632d11d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "af4c9efd-97d6-40a8-810f-1153966ae85d");

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
        }
    }
}
