using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aventureo_Back.Migrations
{
    /// <inheritdoc />
    public partial class rolesUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_email",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RolAdmin",
                table: "Usuario",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_email",
                table: "Usuario",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RolAdmin",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_email",
                table: "Usuario",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }
    }
}
