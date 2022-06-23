using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraFCVSJ.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotEmpty();

            RuleFor(x => x.Login)
                .Matches(new Regex(@"^[.@a-zA-Z-0-9]{3,60}$")).WithMessage("Login de usuário informado é inválido.")
                .NotEmpty();

            RuleFor(x => x.Senha)
                .Matches(new Regex(@"^[.!@#$%&*a-zA-Z-0-9]{10,25}$")).WithMessage("Senha informada é inválida.")
                .NotEmpty();

            RuleFor(x => x.Salario)
                .GreaterThanOrEqualTo(1100)
                .NotEmpty();

            RuleFor(x => x.DataAdmissao)
                .LessThanOrEqualTo(DateTime.Now)
                .NotEmpty();

            RuleFor(x => x.NivelAcesso)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(3)
                .NotEmpty();
        }
    }
}
