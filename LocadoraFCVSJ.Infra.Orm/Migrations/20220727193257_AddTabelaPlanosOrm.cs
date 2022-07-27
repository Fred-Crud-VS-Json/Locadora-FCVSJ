using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraFCVSJ.Infra.Orm.Migrations
{
    public partial class AddTabelaPlanosOrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoOrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoDiario_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoDiario_ValorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoLivre_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoControlado_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoControlado_ValorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoControlado_LimiteKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoOrm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoOrm_TBGrupoOrm_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoOrm_GrupoId",
                table: "TBPlanoOrm",
                column: "GrupoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoOrm");
        }
    }
}
