using FluentValidation;

namespace LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoLivre : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoLivre()
        {
            RuleFor(x => x.PlanoLivre_ValorDiario)
                .GreaterThan(0);
        }
    }
}