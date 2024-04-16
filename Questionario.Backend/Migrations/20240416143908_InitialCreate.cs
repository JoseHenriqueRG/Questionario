using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionario.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaixaIdade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaixaIdade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaixaSalarial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaixaSalarial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivoEmprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoEmprestimo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaixaIdadeId = table.Column<int>(type: "int", nullable: false),
                    ConvenioId = table.Column<int>(type: "int", nullable: false),
                    FaixaSalarialId = table.Column<int>(type: "int", nullable: false),
                    MotivoEmprestimoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resposta_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resposta_FaixaIdade_FaixaIdadeId",
                        column: x => x.FaixaIdadeId,
                        principalTable: "FaixaIdade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resposta_FaixaSalarial_FaixaSalarialId",
                        column: x => x.FaixaSalarialId,
                        principalTable: "FaixaSalarial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resposta_MotivoEmprestimo_MotivoEmprestimoId",
                        column: x => x.MotivoEmprestimoId,
                        principalTable: "MotivoEmprestimo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_ConvenioId",
                table: "Resposta",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_FaixaIdadeId",
                table: "Resposta",
                column: "FaixaIdadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_FaixaSalarialId",
                table: "Resposta",
                column: "FaixaSalarialId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_MotivoEmprestimoId",
                table: "Resposta",
                column: "MotivoEmprestimoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropTable(
                name: "FaixaIdade");

            migrationBuilder.DropTable(
                name: "FaixaSalarial");

            migrationBuilder.DropTable(
                name: "MotivoEmprestimo");
        }
    }
}
