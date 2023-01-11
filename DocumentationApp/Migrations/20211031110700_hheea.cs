using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentationApp.Migrations
{
    public partial class hheea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentTitle",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-421f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fd1d81ba-d547-4153-8351-bbbd2e6e48bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "00d8d4ce-942b-47a4-b635-9dfd4f1978d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36d681dc-e5ca-4a90-b2e3-3b6baa5dcb4d", "AQAAAAEAACcQAAAAEH5fV/jlaGkstSw50JCSylUl0dFnXsCaN3hTzwiKvjORPMbyiULlA3Pw2SI7TBudag==", "af48179a-80c8-475f-aa7e-5f3d7e94d4e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9550d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb373503-b19d-4c10-a78c-f56d715dcaaa", "AQAAAAEAACcQAAAAEL8WyFolJtNfLpBiq1OVlqZvS3c+idWubbFW5or5zF1hQoKjP3w+ekwl+B/QU5i8xw==", "3e5d9e61-5d19-44ed-9a3e-31d6914105a6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentTitle",
                table: "Contents");

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
    }
}
