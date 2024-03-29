﻿using FluentAssertions;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado.Utils;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaTestes
    {
        private PlanoDeCobranca? planoDeCobranca;
        private Grupo? grupo;

        private readonly RepositorioPlanoDeCobrancaSql repositorioPlanoDeCobranca;
        private readonly RepositorioGrupoSql repositorioGrupo;

        public RepositorioPlanoDeCobrancaTestes()
        {
            SqlUtil.ExecutarSql("DELETE FROM [TBCondutor]");
            SqlUtil.ExecutarSql("DELETE FROM [TBCliente]");
            SqlUtil.ExecutarSql("DELETE FROM [TBVeiculo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBPlanoDeCobranca]");
            SqlUtil.ExecutarSql("DELETE FROM [TBGrupo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBTaxa]");
            SqlUtil.ExecutarSql("DELETE FROM [TBFuncionario]");

            repositorioPlanoDeCobranca = new();
            repositorioGrupo = new();
        }

        [TestMethod]
        public void Deve_Inserir_PlanoDeCobranca()
        {
            // arrange
            grupo = NovoGrupo();
            planoDeCobranca = NovoPlanoDeCobranca();

            repositorioGrupo.Inserir(grupo);

            // action
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            // assert
            PlanoDeCobranca? planoEncontrado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            planoEncontrado.Should().NotBeNull();
            planoEncontrado.Should().Be(planoDeCobranca);
        }

        [TestMethod]
        public void Deve_Editar_PlanoDeCobranca()
        {
            // arrange
            grupo = NovoGrupo();
            planoDeCobranca = NovoPlanoDeCobranca();

            repositorioGrupo.Inserir(grupo);
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            // action
            planoDeCobranca.PlanoDiario_ValorDiario = 8.50m;
            planoDeCobranca.PlanoDiario_ValorKm = 6.50m;
            planoDeCobranca.PlanoLivre_ValorDiario = 15.00m;
            planoDeCobranca.PlanoControlado_ValorDiario = 7.30m;
            planoDeCobranca.PlanoControlado_ValorKm = 5.00m;
            planoDeCobranca.PlanoControlado_LimiteKm = 1000;

            repositorioPlanoDeCobranca.Editar(planoDeCobranca);

            // assert
            PlanoDeCobranca? planoEncontrado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            planoEncontrado.Should().NotBeNull();
            planoEncontrado.Should().Be(planoDeCobranca);
        }

        [TestMethod]
        public void Deve_Excluir_PlanoDeCobranca()
        {
            // arrange
            grupo = NovoGrupo();
            planoDeCobranca = NovoPlanoDeCobranca();

            repositorioGrupo.Inserir(grupo);
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            // action
            repositorioPlanoDeCobranca.Excluir(planoDeCobranca);

            // assert
            PlanoDeCobranca? planoEncontrado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            planoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_PlanoDeCobranca_Por_Id()
        {
            // arrange
            grupo = NovoGrupo();
            planoDeCobranca = NovoPlanoDeCobranca();

            repositorioGrupo.Inserir(grupo);
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            // action
            PlanoDeCobranca? planoEncontrado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            // assert
            planoEncontrado.Should().NotBeNull();
            planoEncontrado.Should().Be(planoDeCobranca);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Os_PlanosDeCobranca()
        {
            // arrange
            grupo = NovoGrupo();
            planoDeCobranca = NovoPlanoDeCobranca();

            repositorioGrupo.Inserir(grupo);
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            Grupo grupo2 = new() { Nome = "Grupo B - Econômico" };

            PlanoDeCobranca planoDeCobranca2 = new()
            {
                Grupo = grupo2,
                PlanoDiario_ValorDiario = 8.50m,
                PlanoDiario_ValorKm = 6.50m,
                PlanoLivre_ValorDiario = 15.00m,
                PlanoControlado_ValorDiario = 7.30m,
                PlanoControlado_ValorKm = 5.00m,
                PlanoControlado_LimiteKm = 1000,
            };

            repositorioGrupo.Inserir(grupo2);
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca2);

            // action
            List<PlanoDeCobranca> planos = repositorioPlanoDeCobranca.SelecionarTodos();

            // assert    
            planos.Count.Should().Be(2);
            planos.Should().Contain(planoDeCobranca);
            planos.Should().Contain(planoDeCobranca2);
        }

        private PlanoDeCobranca NovoPlanoDeCobranca()
        {
            return new()
            {
                Grupo = grupo,
                PlanoDiario_ValorDiario = 5.50m,
                PlanoDiario_ValorKm = 2.50m,
                PlanoLivre_ValorDiario = 8.80m,
                PlanoControlado_ValorDiario = 4.30m,
                PlanoControlado_ValorKm = 2.00m,
                PlanoControlado_LimiteKm = 500
            };
        }

        private Grupo NovoGrupo()
        {
            return new()
            {
                Nome = "Grupo A - Compacto"
            };
        }

    }
}