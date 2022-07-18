using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraFCVSJ.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{3,60}$")).WithMessage("Nome informado é inválido. Lembre-se de preenche-lo corretamente.\n (Min 3 caracteres, Max 60 caracteres)\n (Acentos e espaços são permitidos)\n");
            
            RuleFor(x => x.CPF)
                .Matches(new Regex(@"^[0-9]{11}$")).WithMessage("CPF informado é inválido. Lembre-se de preenche-lo corretamente.\n (11 caracteres)\n");

            RuleFor(x => x.CEP)
                .Matches(new Regex(@"^[0-9]{8}$")).WithMessage("CEP informado é inválido. Lembre-se de preenche-lo corretamente.\n (8 caracteres)\n");

            RuleFor(x => x.UF)
                .NotEmpty().WithMessage("UF informada é inválida. \n");

            RuleFor(x => x.Cidade)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{5,60}$")).WithMessage("Cidade informada é inválida. Lembre-se de preenche-la corretamente.\n (Min  caracteres, Max 60 caracteres)\n (Acentos e espaços são permitidos)\n");

            RuleFor(x => x.Bairro)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{2,60}$")).WithMessage("Bairro informado é inválido. Lembre-se de preenche-lo corretamente.\n (Min 2 caracteres, Max 60 caracteres)\n (Acentos e espaços são permitidos)\n");

            RuleFor(x => x.Numero)
                .Matches(new Regex(@"^[0-9]{1,5}$")).WithMessage("Número informado é inválido. Lembre-se de preenche-lo corretamente.\n");

            RuleFor(x => x.Rua)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{2,150}$")).WithMessage("Rua informada é inválido. Lembre-se de preenche-la corretamente.\n (Min 2 caracteres, Max 150 caracteres)\n (Acentos e espaços são permitidos)\n");

            RuleFor(x => x.Complemento)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{2,60}$")).WithMessage("Complemento informado é inválido. Lembre-se de preenche-lo corretamente.\n (Min 2 caracteres, Max 60 caracteres)\n (Acentos e espaços são permitidos)\n");

            RuleFor(x => x.CNH)
                .Matches(new Regex(@"^[0-9]{11}$")).WithMessage("CNH informado é inválido. Lembre-se de preenche-la corretamente.\n (11 caracteres)\n");

            RuleFor(x => x.Telefone)
                .Matches(new Regex(@"^[0-9]{11}$")).WithMessage("Telefone informado é inválido. Lembre-se de preenche-lo corretamente.\n (11 caracteres)\n");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("E-mail informado é inválido. Lembre-se de preenche-lo corretamente.");

            When(x => x.CNPJ != null, () =>
            {
                RuleFor(x => x.CNPJ)
                    .Matches(new Regex(@"^[0-9]{14}$")).WithMessage("\nCNPJ informado é inválido. Lembre-se de preenche-lo corretamente.\n (14 caracteres) \n");
            });
        }
    }
}