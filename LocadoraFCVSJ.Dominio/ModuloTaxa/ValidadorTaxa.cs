using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraFCVSJ.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{3,60}$")).WithMessage("Nome informado é inválido. Lembre-se de preenche-lo corretamente. \n(Min 3 caracteres, Max 60 caracteres) \n(Acentos e espaços são permitidos)\n");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("Valor informado é inválido. Lembre-se de preenche-lo corretamente.\n");

            RuleFor(x => x.TipoCalculoTaxa)
                .NotEmpty().WithMessage("Tipo de Cálculo de Taxa informado é inválido.");
        }
    }
}