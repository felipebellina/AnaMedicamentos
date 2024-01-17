using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMedicamentos.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoNomeDaColunaDataAtualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataAtualização",
                table: "Usuarios",
                newName: "DataAtualizacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Usuarios",
                newName: "DataAtualização");
        }
    }
}
