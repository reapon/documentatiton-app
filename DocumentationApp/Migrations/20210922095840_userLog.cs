using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class userLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Contents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Contents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Contents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8f83243e-983f-43f2-a283-2ac4beec49b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bbb2741-ab59-42d9-b8a7-a290a4ce9397", "AQAAAAEAACcQAAAAEER9MU8pO5P2/oDHc27REtjBF7Hu83q0O05LhoylJ3jVLd8in6ZxoHN5cMaQAv4+gQ==", "aa12b7dd-a342-4d6a-a0fa-8c812394ed46" });
        }
    }
}
