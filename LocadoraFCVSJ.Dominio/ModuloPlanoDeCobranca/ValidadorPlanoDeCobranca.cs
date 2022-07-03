using FluentValidation;

namespace LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.PlanoDiario_ValorDiario)
                .GreaterThan(0);

            RuleFor(x => x.PlanoDiario_ValorKm)
                .GreaterThan(0);

            RuleFor(x => x.PlanoLivre_ValorDiario)
                .GreaterThan(0);

            RuleFor(x => x.PlanoControlado_ValorDiario)
                .GreaterThan(0);

            RuleFor(x => x.PlanoControlado_ValorKm)
                 .GreaterThan(0);

            RuleFor(x => x.PlanoControlado_LimiteKm)
                .GreaterThan(0);
        }
    }
}