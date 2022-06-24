﻿using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraFCVSJ.Dominio.ModuloTaxas
{
    public class TaxaValidador : AbstractValidator<Taxa>
    {
        public TaxaValidador()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^[ a-zA-Z-à-ü]{3,60}$")).WithMessage("Nome informado é inválido. Lembre-se de preenche-lo corretamente. \n(Min 3 caracteres, Max 60 caracteres) \n(Acentos e espaços são permitidos)\n");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("Valor informado é inválido. Lembre-se de preenche-lo corretamente.");
        }
    }
}