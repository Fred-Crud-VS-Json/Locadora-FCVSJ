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

            planoDeCobranca.PlanoDiario_ValorDiario = -50.45m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoDiario_ValorDiario);
        }

        [TestMethod]
        public void PlanoDiario_Valor_Km_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoDiario_ValorKm = -10.50m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoDiario_ValorKm);
        }

        [TestMethod]
        public void PlanoLivre_Valor_Diario_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoLivre_ValorDiario = -4.40m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoLivre_ValorDiario);
        }

        [TestMethod]
        public void PlanoControlado_Valor_Diario_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoControlado_ValorDiario = -2.25m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoControlado_ValorDiario);
        }

        [TestMethod]
        public void PlanoControlado_Valor_Km_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoControlado_ValorKm = -0.54m;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoControlado_ValorKm);
        }

        [TestMethod]
        public void PlanoControlado_Limite_Km_Deve_Ser_Valido()
        {
            // arrange
            planoDeCobranca = ObterNovoPlanoDeCobranca();

            planoDeCobranca.PlanoControlado_LimiteKm = -16478;
            // action
            TestValidationResult<PlanoDeCobranca> resultado = validador.TestValidate(planoDeCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoControlado_LimiteKm);
        }

        private PlanoDeCobranca ObterNovoPlanoDeCobranca()
        {
            Grupo grupo = new() { Nome = "Grupo A - Compacto" };

            return new()
            {
                Grupo = grupo,
                PlanoDiario_ValorDiario = 15.30m,
                PlanoDiario_ValorKm = 5.30m,
                PlanoLivre_ValorDiario = 25.50m,
                PlanoControlado_ValorDiario = 12.00m,
                PlanoControlado_ValorKm = 3.50m,
                PlanoControlado_LimiteKm = 10000
            };
        }
    }
}