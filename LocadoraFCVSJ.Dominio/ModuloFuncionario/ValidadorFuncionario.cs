using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraFCVSJ.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{3,60}$")).WithMessage("Nome informado é inválido. Lembre-se de preenche-lo corretamente. \n(Min 3 caracteres, Max 60 caracteres) \n(Acentos e espaços são permitidos)\n");

            RuleFor(x => x.Usuario)
                .Matches(new Regex(@"^[.@a-zA-Z-0-9]{3,60}$")).WithMessage("Usuário informado é inválido. Lembre-se de preenche-lo corretamente. \n(Min 3 caracteres, Max 60 caracteres) \n(Caracteres Especiais Permitidos: [.@])\n");

            RuleFor(x => x.Senha)
                .Matches(new Regex(@"^[.!@#$%&*a-zA-Z-0-9]{10,25}$")).WithMessage("Senha informada é inválida. Lembre-se de preenche-la corretamente. \n(Min 10 caracteres, Max 25 caracteres) \n(Caracteres Especiais Permitidos: [.!@#$%&*]\n");

            RuleFor(x => x.Salario)
                .GreaterThan(0).WithMessage("Salário informado é inválido. Lembre-se de preenche-lo corretamente.");

            RuleFor(x => x.DataAdmissao)
                .LessThanOrEqualTo(DateTime.Now);
        }
    }
}
