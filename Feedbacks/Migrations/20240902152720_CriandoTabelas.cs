using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feedbacks.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Funcao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Prioridade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Data_Final = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Projeto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Data_Final = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ColaboradorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Projetos_TB_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "TB_Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Projetos_ColaboradorId",
                table: "TB_Projetos",
                column: "ColaboradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Projetos");

            migrationBuilder.DropTable(
                name: "TB_Colaboradores");
        }
    }
}
