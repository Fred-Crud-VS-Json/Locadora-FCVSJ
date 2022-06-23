using FluentValidation.TestHelper;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private Cliente? cliente;
        private ValidadorCliente validador;

        public ValidadorClienteTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Nome = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.Nome = "@123";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Dado_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Dado = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Dado);
        }

        [TestMethod]
        public void Endereco_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Endereco = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Endereco);
        }

        [TestMethod]
        public void Tipo_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Tipo = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Tipo);
        }

        [TestMethod]
        public void Tipo_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.Tipo = "@123";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Tipo);
        }

        [TestMethod]
        public void CNH_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.CNH = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CNH);
        }

        [TestMethod]
        public void CNH_deve_ser_valida()
        {
            cliente = NovoCliente();

            cliente.CNH = "123";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CNH);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Telefone = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Email = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }

        private Cliente NovoCliente()
        {
            return new Cliente
            {
                Nome = "Fulano",
                Dado = "000120",
                Endereco = "Rua jl",
                Tipo = "normal",
                CNH = "0000",
                Telefone = "121212",
                Email = "Fulano@gmail.com"
            };
        }

    }
}
