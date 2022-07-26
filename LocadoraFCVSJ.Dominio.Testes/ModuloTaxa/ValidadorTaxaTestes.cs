using FluentValidation.TestHelper;
using LocadoraFCVSJ.Dominio.Compartilhado.Enums;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloTaxa
{
    [TestClass]
    public class ValidadorGrupoTestes
    {
        private Taxa? taxa;
        private readonly ValidadorTaxa validador;

        public ValidadorGrupoTestes()
        {
            validador = new();
        }

        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            // arrange
            taxa = NovaTaxa();

            taxa.Nome = "";

            // action
            TestValidationResult<Taxa> resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(taxa => taxa.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ser_Valido()
        {
            // arrange
            taxa = NovaTaxa();

            taxa.Nome = "@#@#__ $@!#gru)Ox0";

            // action
            TestValidationResult<Taxa> resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(taxa => taxa.Nome);
        }

        [TestMethod]
        public void Nome_Esta_Correto()
        {
            // arrange
            taxa = NovaTaxa();

            // action
            TestValidationResult<Taxa> resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldNotHaveValidationErrorFor(taxa => taxa.Nome);
        }

        [TestMethod]
        public void Valor_Deve_Ser_Valido()
        {
            // arrange
            taxa = NovaTaxa();

            taxa.Valor = -1;

            // action
            TestValidationResult<Taxa> resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(taxa => taxa.Valor);
        }

        [TestMethod]
        public void Valor_Esta_Correto()
        {
            // arrange
            taxa = NovaTaxa();

            taxa.Valor = 25.40m;

            // action
            TestValidationResult<Taxa> resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldNotHaveValidationErrorFor(taxa => taxa.Valor);
        }

        private Taxa NovaTaxa()
        {
            return new Taxa
            {
                Nome = "Taxa Top",
                Valor = 25.00m,
                TipoCalculoTaxa = TipoCalculoTaxa.Fixa
            };
        }
    }
}