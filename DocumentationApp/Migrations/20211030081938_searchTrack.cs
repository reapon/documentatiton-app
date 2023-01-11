using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class searchTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchByUsers",
                columns: table => new
                {
                    SearchByUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchedWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchByUsers", x => x.SearchByUserID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-421f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f88aed9d-30b0-48a2-94f7-844373138bb8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1e8d6eb4-92ca-405b-9b5e-a735726dccd6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3b23793-a838-47ed-94a9-be71de6084b6", "AQAAAAEAACcQAAAAEDq0YgdzmSIF3SLndA9qWftmq0RMMk6KulmJdvSrbwUcQ2kyDas4Qzw/+ghEyGa41g==", "7da8e5a8-63da-4535-a9e4-44e1bf39dc23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9550d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c73f219-f4f4-4d61-9185-e3d5ac20f7b7", "AQAAAAEAACcQAAAAEHS4ez716IyK3ZCgRGgGESeAOE4LoXd+aERaH3fZnVvW1Yjhg4u6Q/Z9RPvIn2dVEA==", "9ddd5e8f-7aa0-42bd-977b-600b45bc3a27" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchByUsers");

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
    }
}
