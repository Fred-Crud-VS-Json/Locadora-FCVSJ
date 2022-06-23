using FluentAssertions;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDeDadosTest
    {
        private Cliente cliente;
        private RepositorioClienteEmBancoDeDados repositorio;

        public RepositorioClienteEmBancoDeDadosTest()
        {
            BdUtil.ExecutarSql("DELETE FROM [TBCliente]; DBCC CHECKIDENT (TBCliente, RESEED, 0)");
            cliente = new Cliente("Pedro", "321654987", "Rua Jorge Lacerda", "Normal", "0123456789", "12988754461", "pedro@gmail");
            repositorio = new RepositorioClienteEmBancoDeDados();
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
            cliente.Telefone = "987654321";
            cliente.Email = "Pedro@gmail.com";
            cliente.Endereco = "São José dos Campos";
            cliente.Tipo = "Jurídico";
            cliente.CNH = "1234567891";
            cliente.Dado = "00012003";

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
            var c01 = new Cliente("Pedro", "321654986", "Rua Gov Jorge Lacerda", "Normal", "1234567891", "12988754461", "pedo@gmail");
            var c02 = new Cliente("João", "321654985", "Rua Jorge Lacerda", "Normal", "1234567891", "1298875461", "pedr@gmail");
            var c03 = new Cliente("Lucas", "321654987", "Rua Jorg Lacerda", "Jurídico", "1234567891", "12988754461", "pedro@gmail");

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
