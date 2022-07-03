using FluentValidation.TestHelper;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloPlanoDeCobranca
{
    [TestClass]
    public class ValidadorPlanoDeCobrancaTestes
    {
        private PlanoDeCobranca? planoDeCobranca;
        private readonly ValidadorPlanoDeCobranca validador;

        public ValidadorPlanoDeCobrancaTestes()
        {
            validador = new();
        }

        [TestMethod]
        public void PlanoDiario_Valor_Diario_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoDiarioValorDiario = -50.45m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoDiarioValorDiario);
        }

        [TestMethod]
        public void PlanoDiario_Valor_Km_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoDiarioValorKm = -10.50m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoDiarioValorKm);
        }

        [TestMethod]
        public void PlanoLivre_Valor_Diario_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoLivreValorDiario = -4.40m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoLivreValorDiario);
        }

        [TestMethod]
        public void PlanoControlado_Valor_Diario_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoControladoValorDiario = -2.25m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoControladoValorDiario);
        }

        [TestMethod]
        public void PlanoControlado_Valor_Km_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoControladoValorKm = -0.54m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoControladoValorKm);
        }

        [TestMethod]
        public void PlanoControlado_Limite_Km_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoControladoLimiteKm = -16478;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoControladoLimiteKm);
        }

        private PlanoDeCobranca ObterNovoPlanoDeCobranca()
        {
            Grupo grupo = new() { Nome = "Grupo A - Compacto" };

            return new()
            {
                Grupo = grupo,
                PlanoDiarioValorDiario = 15.30m,
                PlanoDiarioValorKm = 5.30m,
                PlanoLivreValorDiario = 25.50m,
                PlanoControladoValorDiario = 12.00m,
                PlanoControladoValorKm = 3.50m,
                PlanoControladoLimiteKm = 10000
            };
        }
    }
}