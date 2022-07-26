using FluentAssertions;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado.Utils;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Testes.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorTestes
    {
        private Condutor? condutor;
        private Condutor? condutor2;
        private Cliente? cliente;
        private Cliente? cliente2;

        private readonly RepositorioCondutorSql repositorioCondutor;
        private readonly RepositorioClienteSql repositorioCliente;

        public RepositorioCondutorTestes()
        {
            SqlUtil.ExecutarSql("DELETE FROM [TBCondutor]");
            SqlUtil.ExecutarSql("DELETE FROM [TBCliente]");
            SqlUtil.ExecutarSql("DELETE FROM [TBVeiculo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBPlanoDeCobranca]");
            SqlUtil.ExecutarSql("DELETE FROM [TBGrupo]");
            SqlUtil.ExecutarSql("DELETE FROM [TBTaxa]");
            SqlUtil.ExecutarSql("DELETE FROM [TBFuncionario]");

            repositorioCliente = new RepositorioClienteSql();
            repositorioCondutor = new RepositorioCondutorSql();
        }

        [TestMethod]
        public void Deve_Inserir_Condutor()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();

            repositorioCliente.Inserir(cliente);

            // action
            repositorioCondutor.Inserir(condutor);

            //assert
            Condutor? condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_Editar_Condutor()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();

            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

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

            //action
            repositorioCondutor.Editar(condutor);

            //assert
            Condutor? condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_Excluir_Condutor()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();

            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            //action           
            repositorioCondutor.Excluir(condutor);

            //assert
            Condutor? condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Condutor_Por_Id()
        {
            // arrange
            cliente = NovoCliente();
            condutor = NovoCondutor();

            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            //action
            Condutor? condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            //assert
            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Os_Condutores()
        {
            // arrange
            cliente = NovoCliente();
            cliente2 = NovoCliente2();
            condutor = NovoCondutor();
            condutor2 = NovoCondutor2();

            repositorioCliente.Inserir(cliente);
            repositorioCliente.Inserir(cliente2);
            repositorioCondutor.Inserir(condutor);
            repositorioCondutor.Inserir(condutor2);

            //action
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos();

            //assert
            condutores.Count.Should().Be(2);
            condutores.Should().Contain(condutor);
            condutores.Should().Contain(condutor2);
        }

        private Condutor NovoCondutor()
        {
            return new Condutor
            {
                Nome = "Alan",
                CPF = "59643424718",
                CNPJ = "12345678912345",
                Rua = "Alameda",
                CNH = "0123456789",
                ValidadeCnh = DateTime.Now.Date,
                Telefone = "12988754461",
                Email = "Alan@gmail.com",
                Cidade = "Lages",
                CEP = "01234567",
                Numero = "212",
                Bairro = "Coral",
                UF = UF.SP,
                Complemento = "verde",
                Cliente = cliente
            };
        }

        private Condutor NovoCondutor2()
        {
            return new Condutor
            {
                Nome = "Eduardo",
                CPF = "59643424718",
                CNPJ = "12345678912345",
                Rua = "Alameda",
                CNH = "0123456789",
                ValidadeCnh = DateTime.Now.Date,
                Telefone = "12988754461",
                Email = "Eduardo@gmail.com",
                Cidade = "Lages",
                CEP = "01234567",
                Numero = "212",
                Bairro = "Coral",
                UF = UF.SP,
                Complemento = "verde",
                Cliente = cliente2
            };
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