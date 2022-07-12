using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;
using Serilog;

namespace LocadoraFCVSJ.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa 
    {
        private readonly RepositorioTaxa _repositorioTaxa;

        public ServicoTaxa(RepositorioTaxa repositorioTaxa)
        {
            _repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir nova taxa...");

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                _repositorioTaxa.Inserir(taxa);
                Log.Logger.Information($"Taxa {taxa.Id} inserida com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir a taxa {taxa.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa...");

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                _repositorioTaxa.Editar(taxa);
                Log.Logger.Information($"Taxa {taxa.Id} editada com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar a taxa {taxa.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            AbstractValidator<Taxa> validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (NomeDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome informado já existe."));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Taxa taxa)
        {
            string query = _repositorioTaxa.QuerySelecionarPorNome;

            Taxa? taxaEncontrada = _repositorioTaxa.SelecionarPropriedade(query, "NOME", taxa.Nome);

            return taxaEncontrada != null
                && taxaEncontrada.Nome.Equals(taxa.Nome, StringComparison.OrdinalIgnoreCase)
                && taxaEncontrada.Id != taxa.Id;
        }
    }
}