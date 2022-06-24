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

            RuleFor(x => x.CPF)
                .Length(11).WithMessage("O Cpf deve ter pelo menos 11 caracteres!")
                .NotEmpty().WithMessage("Deve ser inserido um dado");

            RuleFor(x => x.CNH)
                .Length(10).WithMessage("A Cnh deve ter pelo menos 10 caracteres!")
                .NotEmpty().WithMessage("Deve ser inserido uma CNH");


            RuleFor(x => x.Telefone)
                .Length(11).WithMessage("O Telefone deve ter pelo menos 11 caracteres!")
                .NotEmpty().WithMessage("Deve ser inserido um Telefone");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Deve ser inserido um Email");

            RuleFor(x => x.CNPJ)
                .Length(14).WithMessage("O cnpj deve ter pelo menos 14 caracteres!");

            RuleFor(x => x.Cidade)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{5,60}$")).WithMessage("Cidade informado é inválido.")
                .NotEmpty().WithMessage("Deve ser inserido uma Cidade");

            RuleFor(x => x.CEP)
                .Length(8).WithMessage("O Cep deve ter pelo menos 8 caracteres!")
                .NotEmpty().WithMessage("Deve ser inserido um CEP");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Deve ser inserido um Numero");

            RuleFor(x => x.Bairro)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{5,60}$")).WithMessage("Bairro informado é inválido.")
                .NotEmpty().WithMessage("Deve ser inserido uma Bairro");

            RuleFor(x => x.UF)
               .Matches(new Regex(@"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$")).WithMessage("UF informada é inválida.")
                .NotEmpty().WithMessage("Deve ser inserido um UF");

            RuleFor(x => x.Complemento)
                .NotEmpty().WithMessage("Deve ser inserido um Complemento");

            RuleFor(x => x.Rua)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{5,100}$")).WithMessage("Rua informada é inválida.")
                .NotEmpty().WithMessage("Deve ser inserido uma Rua");
        }



    }
}
