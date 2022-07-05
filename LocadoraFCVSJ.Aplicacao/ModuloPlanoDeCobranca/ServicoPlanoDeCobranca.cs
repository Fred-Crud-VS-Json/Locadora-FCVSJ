using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private readonly RepositorioPlanoDeCobranca _repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(RepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
        {
            _repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public ValidationResult Inserir(PlanoDeCobranca planoDeCobranca)
        {
            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
                _repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca planoDeCobranca)
        {
            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
                _repositorioPlanoDeCobranca.Editar(planoDeCobranca);

            return resultadoValidacao;
        }

        private ValidationResult Validar(PlanoDeCobranca planoDeCobranca)
        {
            AbstractValidator<PlanoDeCobranca> validador = new ValidadorPlanoDeCobranca();

            ValidationResult resultadoValidacao = validador.Validate(planoDeCobranca);

            return resultadoValidacao;
        }
    }
}