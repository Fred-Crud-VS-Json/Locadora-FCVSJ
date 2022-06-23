using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraFCVSJ.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{3,60}$")).WithMessage("Nome informado é inválido.")
                .NotEmpty().WithMessage("Deve ser inserido um nome");

            RuleFor(x => x.Dado)
                .NotEmpty().WithMessage("Deve ser inserido um dado");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("Deve ser inserido um Endereço");

            RuleFor(x => x.Tipo)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{3,60}$")).WithMessage("Tipo informado é inválido.")
                .NotEmpty().WithMessage("Deve ser inserido um Tipo");

            RuleFor(x => x.CNH)
                .Length(10).WithMessage("A cnh deve ter pelo menos 10 caracteres!")
                .NotEmpty().WithMessage("Deve ser inserido uma CNH");


            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("Deve ser inserido um Telefone");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Deve ser inserido um Email");
        }



    }
}
