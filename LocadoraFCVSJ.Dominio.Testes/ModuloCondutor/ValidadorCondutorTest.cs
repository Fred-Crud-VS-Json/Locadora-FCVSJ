using FluentValidation.TestHelper;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        private Condutor? condutor;
        private readonly ValidadorCondutor validador;

        public ValidadorCondutorTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.Nome = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            condutor = NovoCondutor();

            condutor.Nome = "@123";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Cpf_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.CPF = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CPF);
        }

        [TestMethod]
        public void Cpf_deve_ser_valido()
        {
            condutor = NovoCondutor();

            condutor.CPF = "123456";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CPF);
        }

        [TestMethod]
        public void Cnpj_deve_ser_valido()
        {
            condutor = NovoCondutor();

            condutor.CNPJ = "123456";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CNPJ);
        }

        [TestMethod]
        public void CNH_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.CNH = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CNH);
        }

        [TestMethod]
        public void CNH_deve_ser_valida()
        {
            condutor = NovoCondutor();

            condutor.CNH = "123";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CNH);
        }

        [TestMethod]
        public void DataVencimento_deve_ser_valida()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.ValidadeCnh = DateTime.MinValue;

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.ValidadeCnh);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.Telefone = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_ser_valido()
        {
            condutor = NovoCondutor();

            condutor.Telefone = "129887";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.Email = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Email);
        }

        [TestMethod]
        public void Cidade_deve_ser_obrigatoria()
        {
            condutor = NovoCondutor();

            condutor.Cidade = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cidade);
        }

        [TestMethod]
        public void Cep_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.CEP = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CEP);
        }

        [TestMethod]
        public void Cep_deve_ser_valido()
        {
            condutor = NovoCondutor();

            condutor.CEP = "123";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CEP);
        }

        [TestMethod]
        public void Numero_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.Numero = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Numero);
        }

        [TestMethod]
        public void Bairro_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.Bairro = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Bairro);
        }

        [TestMethod]
        public void Uf_deve_ser_obrigatorio()
        {
            condutor = NovoCondutor();

            condutor.UF = null;

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.UF);
        }

        [TestMethod]
        public void Rua_deve_ser_obrigatoria()
        {
            condutor = NovoCondutor();

            condutor.Rua = "";

            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Rua);
        }

        private Condutor NovoCondutor()
        {
            return new Condutor
            {
                Nome = "Fulano",
                CPF = "59643424718",
                CNPJ = "12345678912345",
                Rua = "Alameda",
                CNH = "0123456789",
                ValidadeCnh = DateTime.Now.Date,
                Telefone = "12988754461",
                Email = "Fulano@gmail.com",
                Cidade = "Lages",
                CEP = "01234567",
                Numero = "212",
                Bairro = "Coral",
                UF = UF.SP,
                Complemento = "verde",
                Cliente = NovoCliente()
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
    }
}