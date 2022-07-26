using FluentAssertions;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado.Utils;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteTestes
    {
        private Cliente? cliente;
        private readonly RepositorioClienteSql repositorioCliente;

        public RepositorioClienteTestes()
        {
            SqlUtil.ExecutarSql("DELETE FROM [TBCondutor]");
            SqlUtil.ExecutarSql("DELETE FROM [TBCliente]");
            SqlUtil.ExecutarSql("DELETE FROM [TBVeiculo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBPlanoDeCobranca]");
            SqlUtil.ExecutarSql("DELETE FROM [TBGrupo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBTaxa]");
            SqlUtil.ExecutarSql("DELETE FROM [TBFuncionario]");

            repositorioCliente = new();
        }

        [TestMethod]
        public void Deve_Inserir_Cliente()
        {
            //arrange
            cliente = NovoCliente();

            //action
            repositorioCliente.Inserir(cliente);

            //assert
            Cliente? clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_Editar_Cliente()
        {
            //arrange
            cliente = NovoCliente();

            //arrange                      
            repositorioCliente.Inserir(cliente);

            //action
            cliente.Nome = "Pedro Nunes";
            cliente.CPF = "69643424718";
            cliente.CNPJ = "12345678912345";
            cliente.CNH = "1234567891";
            cliente.Telefone = "12988754461";
            cliente.Email = "Pedro@gmail.com";
            cliente.Cidade = "São José dos Campos";
            cliente.CEP = "01234567";
            cliente.Rua = "Rua Fulano";
            cliente.Numero = "12";
            cliente.Bairro = "Coral";
            cliente.UF = UF.SP;
            cliente.Complemento = "verde";

            repositorioCliente.Editar(cliente);

            //assert
            Cliente? clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_Excluir_Cliente()
        {
            //arrange
            cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);

            //action           
            repositorioCliente.Excluir(cliente);

            //assert
            Cliente? clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Cliente_Por_Id()
        {
            //arrange
            cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);

            //action
            Cliente? clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            //assert

            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Os_Clientes()
        {
            //arrange
            cliente = NovoCliente();

            Cliente cliente2 = NovoCliente2();

            repositorioCliente.Inserir(cliente);
            repositorioCliente.Inserir(cliente2);

            //action
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            //assert
            clientes.Count.Should().Be(2);
            clientes.Should().Contain(cliente);
            clientes.Should().Contain(cliente2);
        }

        private Cliente NovoCliente()
        {
            return new()
            {
                Nome = "Fulano",
                CPF = "59643424718",
                CNPJ = "12345678912345",
                Rua = "Alameda",
                CNH = "0123456789",
                Telefone = "12988754461",
                Email = "Fulano@gmail.com",
                Cidade = "Lages",
                CEP = "01234567",
                Numero = "212",
                Bairro = "Coral",
                UF = UF.SP,
                Complemento = "verde"
            };
        }

        private Cliente NovoCliente2()
        {
            return new()
            {
                Nome = "Fulana",
                CPF = "98443424718",
                CNPJ = "67445678912345",
                Rua = "Alameda",
                CNH = "0123456789",
                Telefone = "12988754461",
                Email = "Fulana@gmail.com",
                Cidade = "Lages",
                CEP = "01234567",
                Numero = "212",
                Bairro = "Coral",
                UF = UF.SC,
                Complemento = "verde"
            };
        }

    }
}