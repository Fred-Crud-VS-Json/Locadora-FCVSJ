using FluentValidation.TestHelper;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private Cliente? cliente;
        private readonly ValidadorCliente validador;

        public ValidadorClienteTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Nome = "";

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
        public void Cpf_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.CPF = "";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF);
        }

        [TestMethod]
        public void Cpf_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.CPF = "123456";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF);
        }

        [TestMethod]
        public void Cnpj_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.CNPJ = "123456";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CNPJ);
        }

        [TestMethod]
        public void CNH_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.CNH = "";

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

            cliente.Telefone = "";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.Telefone = "129887";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Email = "";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }

        [TestMethod]
        public void Cidade_deve_ser_obrigatoria()
        {
            cliente = NovoCliente();

            cliente.Cidade = "";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Cidade);
        }

        [TestMethod]
        public void Cep_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.CEP = "";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CEP);
        }

        [TestMethod]
        public void Cep_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.CEP = "123";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CEP);
        }

        [TestMethod]
        public void Numero_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Numero = "";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Numero);
        }

        [TestMethod]
        public void Bairro_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Bairro = "";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Bairro);
        }

        [TestMethod]
        public void Uf_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.UF = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.UF);
        }

        [TestMethod]
        public void Rua_deve_ser_obrigatoria()
        {
            cliente = NovoCliente();

            cliente.Rua = "";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Rua);
        }

        private Cliente NovoCliente()
        {
            return new Cliente
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

    }
}