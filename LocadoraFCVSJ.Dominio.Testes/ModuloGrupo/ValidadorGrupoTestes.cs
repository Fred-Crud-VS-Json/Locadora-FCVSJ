using FluentValidation.TestHelper;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraFCVSJ.Dominio.Testes.ModuloGrupo
{
    [TestClass]
    public class ValidadorGrupoTestes
    {
        private Grupo? grupo;
        private readonly ValidadorGrupo validador;

        public ValidadorGrupoTestes()
        {
            validador = new();
        }

        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            // arrange
            grupo = NovoGrupo();

            grupo.Nome = "";

            // action
            TestValidationResult<Grupo> resultado = validador.TestValidate(grupo);

            // assert
            resultado.ShouldHaveValidationErrorFor(grupo => grupo.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ser_Valido()
        {
            // arrange
            grupo = NovoGrupo();

            grupo.Nome = "@#@#__ $@!#gru)Ox0";

            // action
            TestValidationResult<Grupo> resultado = validador.TestValidate(grupo);

            // assert
            resultado.ShouldHaveValidationErrorFor(grupo => grupo.Nome);
        }

        [TestMethod]
        public void Nome_Esta_Correto()
        {
            // arrange
            grupo = NovoGrupo();

            // action
            TestValidationResult<Grupo> resultado = validador.TestValidate(grupo);

            // assert
            resultado.ShouldNotHaveValidationErrorFor(grupo => grupo.Nome);
        }

        private Grupo NovoGrupo()
        {
            return new Grupo
            { 
                Nome = "Grupo A - Compacto"
            };
        }
    }
}