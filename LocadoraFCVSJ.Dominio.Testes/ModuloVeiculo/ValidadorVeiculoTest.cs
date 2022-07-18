using FluentValidation.TestHelper;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloVeiculo
{
    [TestClass]
    public class ValidadorVeiculoTest
    {
        private Veiculo? veiculo;
        private readonly ValidadorVeiculo validador;

        public ValidadorVeiculoTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Modelo_deve_ser_obrigatorio()
        {
            //arrange
            veiculo = NovoVeiculo();

            veiculo.Modelo = "";

            //action
            TestValidationResult<Veiculo> resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Modelo);
        }

        [TestMethod]
        public void Marca_deve_ser_obrigatorio()
        {
            //arrange
            veiculo = NovoVeiculo();

            veiculo.Marca = "";

            //action
            TestValidationResult<Veiculo> resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Marca);
        }

        [TestMethod]
        public void Placa_deve_ser_obrigatorio()
        {
            //arrange
            veiculo = NovoVeiculo();

            veiculo.Placa = "";

            //action
            TestValidationResult<Veiculo> resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Placa);
        }

        [TestMethod]
        public void Cor_deve_ser_obrigatorio()
        {
            //arrange
            veiculo = NovoVeiculo();

            veiculo.Cor = "";

            //action
            TestValidationResult<Veiculo> resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Cor);
        }

        [TestMethod]
        public void CapacidadeTanque_deve_ser_maior_ou_igual_0()
        {
            //arrange
            veiculo = NovoVeiculo();

            veiculo.CapacidadeTanque = -1;

            //action
            TestValidationResult<Veiculo> resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.CapacidadeTanque);
        }

        [TestMethod]
        public void Ano_deve_ser_menor_ou_igual_2022()
        {
            //arrange
            veiculo = NovoVeiculo();

            veiculo.Ano = 2025;

            //action
            TestValidationResult<Veiculo> resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Ano);
        }

        [TestMethod]
        public void KmPercorrido_deve_ser_maior_ou_igual_0()
        {
            //arrange
            veiculo = NovoVeiculo();

            veiculo.KmPercorrido = -1;

            //action
            TestValidationResult<Veiculo> resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.KmPercorrido);
        }

        private Veiculo NovoVeiculo()
        {
            Grupo grupo = new() { Nome = "Grupo A - Carro economico"};

            return new Veiculo
            {
                Grupo = grupo,
                Modelo = "Teste",
                Marca = "Ford",
                Placa = "ASD2345",
                Cor = "Preto",
                TipoCombustivel = TipoCombustivel.Gasolina,
                CapacidadeTanque = 200,
                Ano = 2020,
                KmPercorrido = 0,
            };
        }
    }
}