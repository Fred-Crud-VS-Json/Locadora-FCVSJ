using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraFCVSJ.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .Matches(new Regex(@"^[ .a-zA-Z-à-ü-0-9]{2,60}$")).WithMessage("Modelo informado é inválido. Lembre-se de preenche-lo corretamente.\n (Min 2 caracteres, Max 60 caracteres)\n (Acentos, números e espaços são permitidos)\n");

            RuleFor(x => x.Marca)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{2,60}$")).WithMessage("Marca informada é inválida. Lembre-se de preenche-la corretamente.\n (Min 2 caracteres, Max 60 caracteres)\n (Acentos e espaços são permitidos)\n");

            RuleFor(x => x.Placa)
                .Matches(new Regex(@"^[A-Z-0-9]{7}$")).WithMessage("Placa informada é inválida. Lembre-se de preenche-la corretamente.\n (Min 7 caracteres)\n");

            RuleFor(x => x.Cor)
                .Matches(new Regex(@"^[ a-z-A-Z-à-ü]{3,60}$")).WithMessage("Cor informada é inválida. Lembre-se de preenche-la corretamente.\n (Min 3 caracteres, Max 60 caracteres)\n (Acentos e espaços são permitidos)\n");

            RuleFor(x => x.CapacidadeTanque)
                .GreaterThan(0).WithMessage("Capacidade do tanque informado é inválido. Lembre-se de preenche-lo corretamente.\n");

            RuleFor(x => x.TipoCombustivel)
                .NotEmpty();

            RuleFor(x => x.Ano)
                .LessThanOrEqualTo(2023).WithMessage("Ano informado é inválido.\n");

            RuleFor(x => x.KmPercorrido)
                .GreaterThanOrEqualTo(0).WithMessage("Quilometragem informada é inválida. Lembre-se de preenche-la corretamente.\n");
        }
    }
}
