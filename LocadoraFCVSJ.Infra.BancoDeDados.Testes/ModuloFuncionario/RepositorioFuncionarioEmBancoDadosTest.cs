using FluentAssertions;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDadosTest
    {
        private Funcionario? funcionario;
        private readonly RepositorioFuncionario repositorioFuncionario;

        public RepositorioFuncionarioEmBancoDadosTest() 
        {
            BdUtil.ExecutarSql("DELETE FROM [TBFuncionario]; DBCC CHECKIDENT (TBFuncionario, RESEED, 0)");

            repositorioFuncionario = new();
        }

        [TestMethod]
        public void Deve_inserir_funcionario()
        {
            //arrange
            funcionario = NovoFuncionario();

            //action
            repositorioFuncionario.Inserir(funcionario);

            //assert
            Funcionario? funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            funcionarioEncontrado.Should().NotBeNull();
            funcionario.Should().Be(funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_editar_funcionario()
        {
            //arrange
            funcionario = NovoFuncionario();

            //action
            repositorioFuncionario.Inserir(funcionario);

            Funcionario? funcionarioAtualizado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            funcionarioAtualizado.Nome = "Fulano";
            funcionarioAtualizado.Usuario = "FulanoDaSilva";
            funcionarioAtualizado.Senha = "Fulano123567789";
            funcionarioAtualizado.Salario = 1500;
            funcionarioAtualizado.DataAdmissao = DateTime.Now.Date;
            funcionarioAtualizado.NivelAcesso = (NivelAcesso)1;

            //action
            repositorioFuncionario.Editar(funcionarioAtualizado);

            //assert
            Funcionario? funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            funcionarioEncontrado.Should().NotBeNull();
            funcionario.Should().Be(funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange
            funcionario = NovoFuncionario();

            //action
            repositorioFuncionario.Inserir(funcionario);

            //assert
            Funcionario? funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            //action
            repositorioFuncionario.Excluir(funcionario);

            funcionarioEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_todos_funcionarios()
        {
            //arrange
            funcionario = NovoFuncionario();

            //action
            repositorioFuncionario.Inserir(funcionario);

            //arrange
            funcionario = NovoFuncionario2();

            //action
            repositorioFuncionario.Inserir(funcionario);

            //assert
            var funcionarios = repositorioFuncionario.SelecionarTodos();

            //assert
            Assert.AreEqual(2, funcionarios.Count);

            Assert.AreEqual("Fulano", funcionarios[0].Nome);
            Assert.AreEqual("Fulana", funcionarios[1].Nome);
        }

        private Funcionario NovoFuncionario()
        {
            return new Funcionario
            {
                Nome = "Fulano",
                Usuario = "FulanoDaSilva",
                Senha = "Fulano123567789",
                Salario = 1500,
                DataAdmissao = DateTime.Now.Date,
                NivelAcesso = (NivelAcesso)1
            };
        }

        private Funcionario NovoFuncionario2()
        {
            return new Funcionario
            {
                Nome = "Fulana",
                Usuario = "FulanaDaSilveira",
                Senha = "Fulanoa4444657789",
                Salario = 2000,
                DataAdmissao = DateTime.Now.Date,
                NivelAcesso = (NivelAcesso)2
            };
        }
    }
}