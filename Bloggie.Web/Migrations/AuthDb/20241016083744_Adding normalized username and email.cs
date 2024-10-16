using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Addingnormalizedusernameandemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c2217bb-c600-435f-90df-10df7552663e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b03fd4c-a9d1-4fc1-83fb-ea959e3e77c0", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEOZq9wDwf2cG3zv4tIxB++kmo/1AFOSCAYpH+r8tbTr3T+0WsN91TRYKGrzwmLqIRg==", "0dae6a7a-c39f-4a8c-b850-516a7dd11076" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c2217bb-c600-435f-90df-10df7552663e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe982762-2734-4225-8815-c04ef424ba8a", null, null, "AQAAAAIAAYagAAAAEJ9cd9EY20wo9txO41WDD02+CtbwhJzZB7pXynh07JRGmchgYjejO9qV1BkSe9QrJw==", "0546e6c1-f50c-4f95-98ba-e00b0265076d" });
        }
    }
}
