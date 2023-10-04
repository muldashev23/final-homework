using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "UserName" },
                values: new object[] { 1, "admin@gmail.com", new byte[] { 127, 1, 76, 202, 133, 84, 181, 12, 232, 117, 25, 236, 240, 237, 234, 3, 165, 66, 247, 83, 41, 172, 216, 69, 251, 21, 212, 230, 220, 46, 56, 143, 170, 130, 59, 131, 218, 161, 2, 208, 250, 179, 41, 227, 117, 171, 252, 127, 26, 187, 21, 19, 13, 205, 228, 140, 230, 136, 97, 204, 4, 42, 106, 177 }, new byte[] { 237, 174, 128, 229, 153, 84, 222, 56, 220, 18, 160, 3, 60, 141, 69, 111, 143, 99, 104, 147, 133, 83, 150, 187, 148, 159, 113, 234, 60, 19, 116, 229, 38, 78, 27, 254, 149, 165, 17, 146, 125, 2, 96, 128, 130, 234, 120, 18, 246, 37, 20, 139, 143, 177, 66, 30, 56, 170, 230, 154, 137, 96, 208, 223, 135, 181, 158, 136, 139, 57, 9, 28, 44, 238, 198, 13, 226, 95, 41, 207, 89, 92, 197, 137, 51, 194, 30, 184, 84, 231, 207, 42, 30, 99, 23, 108, 113, 164, 94, 219, 200, 172, 55, 127, 212, 112, 147, 82, 249, 8, 232, 143, 3, 106, 114, 100, 253, 151, 21, 110, 64, 80, 73, 30, 175, 250, 168, 233 }, "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
