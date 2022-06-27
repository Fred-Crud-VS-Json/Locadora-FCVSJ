using FluentValidation.TestHelper;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private Funcionario? funcionario;
        private readonly ValidadorFuncionario validador;

        public ValidadorFuncionarioTest() 
        {
            validador = new();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Nome = "";

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

            funcionario.Usuario = "";

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Usuario);
        }

        [TestMethod]
        public void Login_deve_ser_valido()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Usuario = "sdfds fgf";

            //action
            TestValidationResult<Funcionario> resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Usuario);
        }

        [TestMethod]
        public void Senha_deve_ser_obrigatorio()
        {
            //arrange
            funcionario = NovoFuncionario();

            funcionario.Senha = "";

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
                Usuario = "FulanoDaSilva",
                Senha = "Fulano123",
                Salario = 1500,
                DataAdmissao = DateTime.Now.Date,
                NivelAcesso = 0
            };
        }
    }
}