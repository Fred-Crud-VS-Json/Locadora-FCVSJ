using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraFCVSJ.Infra.Orm.Migrations
{
    public partial class AdicionandoTabelas : Migration
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

            migrationBuilder.CreateTable(
                name: "TBFuncionarioOrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NivelAcesso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionarioOrm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoOrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoOrm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxaOrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoCalculoTaxa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxaOrm", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TBVeiculoOrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(10)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTanque = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    KmPercorrido = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculoOrm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculoOrm_TBGrupoOrm_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBCondutorOrm_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutorOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBGrupoOrm_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBPlanoOrm_PlanoDeCobrancaId",
                        column: x => x.PlanoDeCobrancaId,
                        principalTable: "TBPlanoOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBTaxaOrm_TaxaId",
                        column: x => x.TaxaId,
                        principalTable: "TBTaxaOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacaoOrm_TBVeiculoOrm_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculoOrm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutorOrm_ClienteId",
                table: "TBCondutorOrm",
                column: "ClienteId",
                unique: true);

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
                column: "VeiculoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoOrm_GrupoId",
                table: "TBPlanoOrm",
                column: "GrupoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculoOrm_GrupoId",
                table: "TBVeiculoOrm",
                column: "GrupoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFuncionarioOrm");

            migrationBuilder.DropTable(
                name: "TBLocacaoOrm");

            migrationBuilder.DropTable(
                name: "TBCondutorOrm");

            migrationBuilder.DropTable(
                name: "TBPlanoOrm");

            migrationBuilder.DropTable(
                name: "TBTaxaOrm");

            migrationBuilder.DropTable(
                name: "TBVeiculoOrm");

            migrationBuilder.DropTable(
                name: "TBClienteOrm");

            migrationBuilder.DropTable(
                name: "TBGrupoOrm");
        }
    }
}
