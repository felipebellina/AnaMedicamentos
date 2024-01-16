using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMedicamentos.Migrations
{
    /// <inheritdoc />
    public partial class CriandoVinculoUsuarioNaMedicamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCadastro",
                table: "Usuarios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Medicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_UsuarioId",
                table: "Medicamentos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Usuarios_UsuarioId",
                table: "Medicamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Usuarios_UsuarioId",
                table: "Medicamentos");

            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_UsuarioId",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Medicamentos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCadastro",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
