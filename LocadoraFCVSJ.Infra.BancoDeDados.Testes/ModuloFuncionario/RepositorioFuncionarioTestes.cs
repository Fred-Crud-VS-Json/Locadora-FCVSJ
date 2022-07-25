using FluentAssertions;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioTestes
    {
        private Funcionario? funcionario;
        private readonly RepositorioFuncionarioSql repositorioFuncionario;

        public RepositorioFuncionarioTestes() 
        {
            SqlUtil.ExecutarSql("DELETE FROM [TBCondutor]");
            SqlUtil.ExecutarSql("DELETE FROM [TBCliente]");
            SqlUtil.ExecutarSql("DELETE FROM [TBVeiculo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBPlanoDeCobranca]");
            SqlUtil.ExecutarSql("DELETE FROM [TBGrupo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBTaxa]");
            SqlUtil.ExecutarSql("DELETE FROM [TBFuncionario]");

            repositorioFuncionario = new();
        }

        [TestMethod]
        public void Deve_Inserir_Funcionario()
        {
            //arrange
            funcionario = NovoFuncionario();

            //action
            repositorioFuncionario.Inserir(funcionario);

            //assert
            Funcionario? funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            funcionarioEncontrado.Should().NotBeNull();
            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_Editar_Funcionario()
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
            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_Excluir_Funcionario()
        {
            //arrange
            funcionario = NovoFuncionario();

            repositorioFuncionario.Inserir(funcionario);

            //action
            repositorioFuncionario.Excluir(funcionario);

            // assert
            Funcionario? funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            funcionarioEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Funcionario_Por_Id()
        {
            //arrange
            funcionario = NovoFuncionario();

            repositorioFuncionario.Inserir(funcionario);

            //action
            Funcionario? funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            //assert
            funcionarioEncontrado.Should().NotBeNull();
            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Funcionarios()
        {
            //arrange
            funcionario = NovoFuncionario();
            Funcionario funcionario2 = NovoFuncionario2();

            repositorioFuncionario.Inserir(funcionario);
            repositorioFuncionario.Inserir(funcionario2);

            //action
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

            //assert
            funcionarios.Count.Should().Be(2);
            funcionarios.Should().Contain(funcionario);
            funcionarios.Should().Contain(funcionario2);
        }

        private Funcionario NovoFuncionario()
        {
            return new()
            {
                Nome = "Fulano",
                Usuario = "FulanoDaSilva",
                Senha = "Fulano123567789",
                Salario = 1500,
                DataAdmissao = DateTime.Now.Date,
                NivelAcesso = NivelAcesso.Financeiro
            };
        }

        private Funcionario NovoFuncionario2()
        {
            return new()
            {
                Nome = "Fulana",
                Usuario = "FulanaDaSilveira",
                Senha = "Fulanoa4444657789",
                Salario = 2000,
                DataAdmissao = DateTime.Now.Date,
                NivelAcesso = NivelAcesso.Gerente
            };
        }

    }
}