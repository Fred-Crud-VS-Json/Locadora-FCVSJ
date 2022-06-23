using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraFCVSJ.Dominio.ModuloGrupo
{
    public class ValidadorGrupo : AbstractValidator<Grupo>
    {
        public ValidadorGrupo()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{3,60}$")).WithMessage("Nome informado é inválido.")
                .NotEmpty().WithMessage("'Nome' deve ser preenchido.");
        }
    }
}