using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraFCVSJ.Infra.Orm.Migrations
{
    public partial class AddTabelaCondutorOrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCondutorOrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(300)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(300)", nullable: true),
                    CNH = table.Column<string>(type: "varchar(300)", nullable: false),
                    ValidadeCnh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(300)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(300)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(300)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(300)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(300)", nullable: false),
                    UF = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(300)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(300)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutorOrm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutorOrm_TBClienteOrm_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBClienteOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutorOrm_ClienteId",
                table: "TBCondutorOrm",
                column: "ClienteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCondutorOrm");
        }
    }
}
