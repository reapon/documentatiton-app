using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class appPublish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Apps",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Apps");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "df4ca99f-527d-4bdb-8bad-0dfa5f5cbc7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59241662-0f9f-441b-a918-58e07b1ebd3a", "AQAAAAEAACcQAAAAEFViYAG3NfZJLagzkgZwli4R6ec1ZjcFZ+aW2Nw5PmftqYGms0N+asV5SZVpeqWLug==", "c58fadc6-e8d5-442d-b390-db3c6e3bb01d" });
        }
    }
}
