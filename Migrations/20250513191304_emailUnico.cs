using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aventureo_Back.Migrations
{
    /// <inheritdoc />
    public partial class emailUnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Categoria",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "Categoria",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "idCategoria",
                table: "Categoria",
                newName: "IdCategoria");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_email",
                table: "Usuario",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_email",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Categoria",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Categoria",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Categoria",
                newName: "idCategoria");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
