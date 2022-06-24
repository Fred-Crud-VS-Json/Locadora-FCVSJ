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
        public void Cpf_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.CPF = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF);
        }

        public void Cpf_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.CPF = "123456";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF);
        }

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

            cliente.Email = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }

        public void Cidade_deve_ser_obrigatoria()
        {
            cliente = NovoCliente();

            cliente.Cidade= null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Cidade);
        }

        public void Cep_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.CEP = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CEP);
        }

        public void Cep_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.CEP = "123";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CEP);
        }

         public void Numero_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Numero = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Numero);
        }

         public void Bairro_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Bairro = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Bairro);
        }

        public void uf_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.UF = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.UF);
        }

        public void uf_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.UF = "S";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.UF);
        }

        public void Rua_deve_ser_obrigatoria()
        {
            cliente = NovoCliente();

            cliente.Rua = null;

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
                UF = "SP",
                Complemento = "verde"
            };
        }

    }
}
