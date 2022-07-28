using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraFCVSJ.Infra.Orm.Migrations
{
    public partial class AddTabelaLocacaoOrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLocacaoOrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoDeCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime", nullable: false),
                    TaxaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecoEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacaoOrm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBClienteOrm_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBClienteOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBCondutorOrm_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutorOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBGrupoOrm_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBPlanoOrm_PlanoDeCobrancaId",
                        column: x => x.PlanoDeCobrancaId,
                        principalTable: "TBPlanoOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBTaxaOrm_TaxaId",
                        column: x => x.TaxaId,
                        principalTable: "TBTaxaOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBVeiculoOrm_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculoOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacaoOrm_ClienteId",
                table: "TBLocacaoOrm",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacaoOrm_CondutorId",
                table: "TBLocacaoOrm",
                column: "CondutorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacaoOrm_GrupoId",
                table: "TBLocacaoOrm",
                column: "GrupoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacaoOrm_PlanoDeCobrancaId",
                table: "TBLocacaoOrm",
                column: "PlanoDeCobrancaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacaoOrm_TaxaId",
                table: "TBLocacaoOrm",
                column: "TaxaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacaoOrm_VeiculoId",
                table: "TBLocacaoOrm",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBLocacaoOrm");
        }
    }
}
