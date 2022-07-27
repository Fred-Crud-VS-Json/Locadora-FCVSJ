using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraFCVSJ.Infra.Orm.Migrations
{
    public partial class CorrecaoTabelaVeiculoOrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBVeiculoOrm_GrupoId",
                table: "TBVeiculoOrm");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculoOrm_GrupoId",
                table: "TBVeiculoOrm",
                column: "GrupoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBVeiculoOrm_GrupoId",
                table: "TBVeiculoOrm");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculoOrm_GrupoId",
                table: "TBVeiculoOrm",
                column: "GrupoId");
        }
    }
}
