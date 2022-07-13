using FluentValidation;

namespace LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.Grupo)
                .NotEmpty();

            RuleFor(x => x.PlanoDiario_ValorDiario)
                .NotEmpty();

            RuleFor(x => x.PlanoDiario_ValorKm)
                .NotEmpty();

            RuleFor(x => x.PlanoLivre_ValorDiario)
                .NotEmpty();

            RuleFor(x => x.PlanoControlado_ValorDiario)
                .NotEmpty();

            RuleFor(x => x.PlanoControlado_ValorKm)
                .NotEmpty();

            RuleFor(x => x.PlanoControlado_LimiteKm)
                .NotEmpty();
        }
    }
}