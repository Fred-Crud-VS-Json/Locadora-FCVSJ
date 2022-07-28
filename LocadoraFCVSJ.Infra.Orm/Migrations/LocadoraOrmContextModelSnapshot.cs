﻿// <auto-generated />
using System;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraFCVSJ.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraOrmContext))]
    partial class LocadoraOrmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("UF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBClienteOrm", (string)null);
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("UF")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidadeCnh")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("TBCondutorOrm", (string)null);
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime");

                    b.Property<int>("NivelAcesso")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionarioOrm", (string)null);
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloGrupo.Grupo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoOrm", (string)null);
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlanoDeCobrancaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecoEstimado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("TaxaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("CondutorId")
                        .IsUnique();

                    b.HasIndex("GrupoId")
                        .IsUnique();

                    b.HasIndex("PlanoDeCobrancaId")
                        .IsUnique();

                    b.HasIndex("TaxaId")
                        .IsUnique();

                    b.HasIndex("VeiculoId");

                    b.ToTable("TBLocacaoOrm", (string)null);
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlanoControlado_LimiteKm")
                        .HasColumnType("int");

                    b.Property<decimal>("PlanoControlado_ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoControlado_ValorKm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoDiario_ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoDiario_ValorKm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoLivre_ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("PlanoDeCobranca");
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloTaxa.Taxa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoCalculoTaxa")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TBTaxaOrm", (string)null);
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("CapacidadeTanque")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KmPercorrido")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId")
                        .IsUnique();

                    b.ToTable("TBVeiculoOrm", (string)null);
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithOne()
                        .HasForeignKey("LocadoraFCVSJ.Dominio.ModuloCondutor.Condutor", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithOne()
                        .HasForeignKey("LocadoraFCVSJ.Dominio.ModuloLocacao.Locacao", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloCondutor.Condutor", "Condutor")
                        .WithOne()
                        .HasForeignKey("LocadoraFCVSJ.Dominio.ModuloLocacao.Locacao", "CondutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloGrupo.Grupo", "Grupo")
                        .WithOne()
                        .HasForeignKey("LocadoraFCVSJ.Dominio.ModuloLocacao.Locacao", "GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", "PlanoDeCobranca")
                        .WithOne()
                        .HasForeignKey("LocadoraFCVSJ.Dominio.ModuloLocacao.Locacao", "PlanoDeCobrancaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloTaxa.Taxa", "Taxa")
                        .WithOne()
                        .HasForeignKey("LocadoraFCVSJ.Dominio.ModuloLocacao.Locacao", "TaxaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloVeiculo.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");

                    b.Navigation("Grupo");

                    b.Navigation("PlanoDeCobranca");

                    b.Navigation("Taxa");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", b =>
                {
                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloGrupo.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("LocadoraFCVSJ.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.HasOne("LocadoraFCVSJ.Dominio.ModuloGrupo.Grupo", "Grupo")
                        .WithOne()
                        .HasForeignKey("LocadoraFCVSJ.Dominio.ModuloVeiculo.Veiculo", "GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });
#pragma warning restore 612, 618
        }
    }
}
