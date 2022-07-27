using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraFCVSJ.Infra.Orm.Migrations
{
    public partial class AddTabelaClienteOrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBClienteOrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(300)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(300)", nullable: true),
                    CNH = table.Column<string>(type: "varchar(300)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(300)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(300)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(300)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(300)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(300)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(300)", nullable: false),
                    UF = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBClienteOrm", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBClienteOrm");
        }
    }
}
