using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionario.Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "MotivoEmprestimo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "FaixaSalarial",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "FaixaIdade",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Convenio",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "MotivoEmprestimo");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "FaixaSalarial");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "FaixaIdade");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Convenio");
        }
    }
}
