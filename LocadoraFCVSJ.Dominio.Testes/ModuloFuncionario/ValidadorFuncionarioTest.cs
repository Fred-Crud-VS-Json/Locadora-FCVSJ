using FluentValidation.TestHelper;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private Funcionario? funcionario;
        private ValidadorFuncionario validador;

        public ValidadorFuncionarioTest() 
        {
            validador = new();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Nome = null;

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Nome);
        }

        [TestMethod]
        public void Login_deve_ser_obrigatorio()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Login = null;

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Login);
        }

        [TestMethod]
        public void Login_deve_ser_valido()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Login = "sdfds fgf";

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Login);
        }

        [TestMethod]
        public void Senha_deve_ser_obrigatorio()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Senha = null;

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Senha);
        }

        [TestMethod]
        public void Senha_deve_ser_valido()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Senha = "sfsd sdfsdf";

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Senha);
        }

        [TestMethod]
        public void Salario_deve_ser_valido()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Salario = 1000;

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Salario);
        }

        [TestMethod]
        public void DataAdmissao_deve_ser_valido()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.DataAdmissao = DateTime.MaxValue;

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.DataAdmissao);
        }

        private Funcionario NovoFuncionario()
        {
            return new Funcionario
            {
                Nome = "Fulano",
                Login = "FulanoDaSilva",
                Senha = "Fulano123",
                Salario = 1500,
                DataAdmissao = DateTime.Now.Date,
                NivelAcesso = (NivelAcessoEnum)0
            };
        }
    }
}
