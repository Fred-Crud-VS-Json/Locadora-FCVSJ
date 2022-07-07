using FluentValidation;

namespace LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDiario : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDiario()
        {
            RuleFor(x => x.PlanoDiario_ValorDiario)
                .GreaterThan(0);

            RuleFor(x => x.PlanoDiario_ValorKm)
                .GreaterThan(0);
        }
    }
}