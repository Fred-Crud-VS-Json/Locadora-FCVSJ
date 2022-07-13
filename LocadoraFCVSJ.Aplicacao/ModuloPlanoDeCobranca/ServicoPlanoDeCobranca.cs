using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using Serilog;

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
            Log.Logger.Debug("Tentando inserir novo plano de cobrança...");

            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
            {
                _repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
                Log.Logger.Information($"Plano de Cobrança {planoDeCobranca.Id} inserido com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o plano de cobrança {planoDeCobranca.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando editar plano de cobrança...");

            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
            {
                _repositorioPlanoDeCobranca.Editar(planoDeCobranca);
                Log.Logger.Information($"Plano de Cobrança {planoDeCobranca.Id} editado com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o plano de cobrança {planoDeCobranca.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public void Excluir(PlanoDeCobranca planoDeCobranca)
        {
            _repositorioPlanoDeCobranca.Excluir(planoDeCobranca);
        }

        public List<PlanoDeCobranca> SelecionarTodos()
        {
            return _repositorioPlanoDeCobranca.SelecionarTodos();
        }

        private ValidationResult Validar(PlanoDeCobranca planoDeCobranca)
        {
            AbstractValidator<PlanoDeCobranca> validador = new ValidadorPlanoDeCobranca();

            ValidationResult resultadoValidacao = validador.Validate(planoDeCobranca);

            return resultadoValidacao;
        }
    }
}