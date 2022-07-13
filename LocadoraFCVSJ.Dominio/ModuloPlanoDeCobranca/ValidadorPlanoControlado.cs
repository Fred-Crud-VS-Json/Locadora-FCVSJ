using FluentValidation;

namespace LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoControlado : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoControlado()
        {
            RuleFor(x => x.PlanoControlado_ValorDiario)
                .GreaterThan(0);

            RuleFor(x => x.PlanoControlado_ValorKm)
                 .GreaterThan(0);

            RuleFor(x => x.PlanoControlado_LimiteKm)
                .GreaterThan(0);
        }
    }
}