using FluentAssertions;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDeDadosTest
    {
        private readonly Cliente? cliente;
        private readonly RepositorioCliente repositorio;

        public RepositorioClienteEmBancoDeDadosTest()
        {
            BdUtil.ExecutarSql("DELETE FROM [TBCliente]; DBCC CHECKIDENT (TBCliente, RESEED, 0)");
            cliente = new Cliente("Pedro", "59643424718", "12345678912345", "0123456789", "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda");
            repositorio = new RepositorioCliente();
        }

        [TestMethod]
        public void Deve_inserir_novo_clietne()
        {
            //action
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
            cliente.Should().Be(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_do_Clienter()
        {
            //arrange                      
            repositorio.Inserir(cliente);

            //action
            cliente.Nome = "Pedro Nunes";
            cliente.CPF = "69643424718";
            cliente.CNPJ = "12345678912345";
            cliente.CNH = "1234567891";
            cliente.Telefone = "12988754461";
            cliente.Email = "Pedro@gmail.com";
            cliente.Cidade = "São José dos Campos";
            cliente.CEP = "01234567";
            cliente.Numero = "12";
            cliente.Bairro = "Coral";
            cliente.UF = UF.SP;
            cliente.Complemento = "verde";
            cliente.Rua = "Rua Fulano";

            repositorio.Editar(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
            cliente.Should().Be(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange           
            repositorio.Inserir(cliente);

            //action           
            repositorio.Excluir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_cliente()
        {
            //arrange          
            repositorio.Inserir(cliente);

            //action
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
            cliente.Should().Be(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_clientes()
        {
            //arrange
            var c01 = new Cliente("Alan", "59643424719", "12345678912345", "0123456789", "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda");
            var c02 = new Cliente("Eduardo", "59643424718", "12345678912345", "0123456789", "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda");
            var c03 = new Cliente("Pedro", "59643424717", "12345678912345", "0123456789", "12988754461", "pedro@gmail", "lAGES", "01234567", "212", "Centro", UF.SC, "azul", "Alameda");

            repositorio.Inserir(c01);
            repositorio.Inserir(c02);
            repositorio.Inserir(c03);

            //action
            var clientes = repositorio.SelecionarTodos();

            //assert
            clientes.Count.Should().Be(3);

            clientes[0].Should().Be(c01);
            clientes[1].Should().Be(c02);
            clientes[2].Should().Be(c03);

        }
    }
}