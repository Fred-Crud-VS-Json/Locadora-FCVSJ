using FluentAssertions;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorTestes
    {
        private readonly Condutor? condutor;
        private readonly RepositorioCondutor repositorio;
        private readonly Cliente? cliente;
        private readonly RepositorioCliente repositorioCliente;

        public RepositorioCondutorTestes()
        {
            BdUtil.ExecutarSql("DELETE FROM [TBCliente]; DBCC CHECKIDENT (TBCliente, RESEED, 0)");
            BdUtil.ExecutarSql("DELETE FROM [TBCondutor]; DBCC CHECKIDENT (TBCondutor, RESEED, 0)");

            cliente = new Cliente("Pedro", "59643424718", "12345678912345", "0123456789", "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda");
            condutor = new Condutor("Pedro", "59643424718", "12345678912345", "0123456789", DateTime.Now.Date, "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda", cliente);
            repositorioCliente = new RepositorioCliente();
            repositorio = new RepositorioCondutor();
        }

        [TestMethod]
        public void Deve_inserir_novo_condutor()
        {

            //action
            repositorioCliente.Inserir(cliente);
            repositorio.Inserir(condutor);

            //assert
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutor.Should().Be(condutorEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_do_Condutor()
        {
            //arrange
            repositorioCliente.Inserir(cliente);
            repositorio.Inserir(condutor);

            //action
            condutor.Nome = "Pedro Nunes";
            condutor.CPF = "69643424718";
            condutor.CNPJ = "12345678912345";
            condutor.CNH = "1234567891";
            condutor.Telefone = "12988754461";
            condutor.Email = "Pedro@gmail.com";
            condutor.Cidade = "São José dos Campos";
            condutor.CEP = "01234567";
            condutor.Numero = "12";
            condutor.Bairro = "Coral";
            condutor.UF = UF.SP;
            condutor.Complemento = "verde";
            condutor.Rua = "Rua Fulano";

            repositorio.Editar(condutor);

            //assert
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutor.Should().Be(condutorEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //arrange           
            repositorio.Inserir(condutor);

            //action           
            repositorio.Excluir(condutor);

            //assert
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_condutor()
        {
            //arrange          
            repositorioCliente.Inserir(cliente);
            repositorio.Inserir(condutor);

            //action
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            //assert
            condutorEncontrado.Should().NotBeNull();
            condutor.Should().Be(condutorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_condutores()
        {
            //arrange
            repositorioCliente.Inserir(cliente);
            var c01 = new Condutor("Alan", "59643424719", "12345678912345", "0123456789", DateTime.Now.Date, "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda", cliente);
            var c02 = new Condutor("Eduardo", "59643424718", "12345678912345", "0123456789", DateTime.Now.Date, "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda", cliente);
            var c03 = new Condutor("Pedro", "59643424717", "12345678912345", "0123456789", DateTime.Now.Date, "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda", cliente);

            repositorio.Inserir(c01);
            repositorio.Inserir(c02);
            repositorio.Inserir(c03);

            //action
            var condutores = repositorio.SelecionarTodos();

            //assert
            condutores.Count.Should().Be(3);

            condutores[0].Should().Be(c01);
            condutores[1].Should().Be(c02);
            condutores[2].Should().Be(c03);
        }
    }
}
