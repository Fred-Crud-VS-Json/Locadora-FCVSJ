using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraFCVSJ.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.DataLocacao)
                .GreaterThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.DataDevolucao)
                .LessThanOrEqualTo(DateTime.Now.AddDays(30));
        }
    }
}
