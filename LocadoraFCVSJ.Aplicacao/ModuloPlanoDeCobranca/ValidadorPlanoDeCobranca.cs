using FluentValidation;

namespace LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.PlanoDiarioValorDiario)
                .GreaterThan(0);

            RuleFor(x => x.PlanoDiarioValorKm)
                .GreaterThan(0);

            RuleFor(x => x.PlanoLivreValorDiario)
                .GreaterThan(0);

            RuleFor(x => x.PlanoControladoValorDiario)
                .GreaterThan(0);

            RuleFor(x => x.PlanoControladoValorKm)
                 .GreaterThan(0);

            RuleFor(x => x.PlanoControladoLimiteKm)
                .GreaterThan(0);
        }
    }
}