﻿using FluentAssertions;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado.Utils;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloGrupo
{
    [TestClass]
    public class RepositorioGrupoTestes
    {
        private Grupo? grupo;
        private readonly RepositorioGrupoSql repositorioGrupo;

        public RepositorioGrupoTestes()
        {
            SqlUtil.ExecutarSql("DELETE FROM [TBCondutor]");
            SqlUtil.ExecutarSql("DELETE FROM [TBCliente]");
            SqlUtil.ExecutarSql("DELETE FROM [TBVeiculo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBPlanoDeCobranca]");
            SqlUtil.ExecutarSql("DELETE FROM [TBGrupo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBTaxa]");
            SqlUtil.ExecutarSql("DELETE FROM [TBFuncionario]");

            repositorioGrupo = new();
        }

        [TestMethod]
        public void Deve_Inserir_Grupo()
        {
            // arrange
            grupo = NovoGrupo();

            // action
            repositorioGrupo.Inserir(grupo);

            // assert
            Grupo? grupoEncontrado = repositorioGrupo.SelecionarPorId(grupo.Id);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_Editar_Grupo()
        {
            // arrange
            grupo = NovoGrupo();

            repositorioGrupo.Inserir(grupo);

            // action
            grupo.Nome = "Grupo B - Econômico";

            repositorioGrupo.Editar(grupo);

            // assert
            Grupo? grupoEncontrado = repositorioGrupo.SelecionarPorId(grupo.Id);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_Excluir_Grupo()
        {
            // arrange
            grupo = NovoGrupo();

            repositorioGrupo.Inserir(grupo);

            // action
            repositorioGrupo.Excluir(grupo);

            // assert
            Grupo? grupoEncontrado = repositorioGrupo.SelecionarPorId(grupo.Id);

            grupoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Grupo_Por_Id()
        {
            // arrange
            grupo = NovoGrupo();

            repositorioGrupo.Inserir(grupo);

            // action
            Grupo? grupoEncontrado = repositorioGrupo.SelecionarPorId(grupo.Id);

            // assert
            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Os_Grupos()
        {
            // arrange
            grupo = NovoGrupo();

            Grupo grupo2 = new()
            {
                Nome = "Grupo B - Econômico"
            };

            repositorioGrupo.Inserir(grupo);
            repositorioGrupo.Inserir(grupo2);

            // action
            List<Grupo> grupos = repositorioGrupo.SelecionarTodos();

            // assert
            grupos.Count.Should().Be(2);
            grupos.Should().Contain(grupo);
            grupos.Should().Contain(grupo2);
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