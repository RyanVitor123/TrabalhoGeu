using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class VersaoAlterada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Livro",
                table: "Emprestimos",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Emprestimos",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Livro",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Emprestimos");
        }
    }
}
