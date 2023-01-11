using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class neh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "29f33783-fb77-411e-be5e-54af214a9236");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2ecab75-2bd8-463e-a085-ce227d001295", "AQAAAAEAACcQAAAAELhQpcAuOfGri2Zm9VHE4uLm55efbd+uzWiIJjzcwEY9/XoAaawrH7BrK5N+uLDNtQ==", "7e21dd95-0d2f-4a96-b620-527a9263c683" });
        }
    }
}
