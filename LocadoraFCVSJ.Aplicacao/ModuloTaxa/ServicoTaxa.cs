using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private readonly RepositorioTaxa _repositorioTaxa;
        private string _msgErro = "";

        public ServicoTaxa(RepositorioTaxa repositorioTaxa)
        {
            _repositorioTaxa = repositorioTaxa;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa...");

            Result resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir a taxa {taxa.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioTaxa.Inserir(taxa);

                Log.Logger.Information($"Taxa {taxa.Id} inserida com sucesso!");

                return Result.Ok(taxa);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir taxa.";

                Log.Logger.Fatal(ex, _msgErro + $" {taxa.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa...");

            Result resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar a taxa {taxa.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioTaxa.Editar(taxa);

                Log.Logger.Information($"Taxa {taxa.Id} editada com sucesso!");

                return Result.Ok(taxa);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar taxa.";

                Log.Logger.Fatal(ex, _msgErro + $" {taxa.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Taxa> Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir taxa...");

            try
            {
                _repositorioTaxa.Excluir(taxa);

                Log.Logger.Information($"Taxa {taxa.Id} excluída com sucesso!");

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir taxa.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioTaxa.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todas as taxas.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        private Result Validar(Taxa taxa)
        {
            AbstractValidator<Taxa> validador = new ValidadorTaxa();

            ValidationResult resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (NomeDuplicado(taxa))
                erros.Add(new("Nome informado já existe."));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Taxa taxa)
        {
            string query = _repositorioTaxa.QuerySelecionarPorNome;

            Taxa? taxaEncontrado = _repositorioTaxa.SelecionarPropriedade(query, "NOME", taxa.Nome);

            return taxaEncontrado != null
                && taxaEncontrado.Nome.Equals(taxa.Nome, StringComparison.OrdinalIgnoreCase)
                && taxaEncontrado.Id != taxa.Id;
        }
    }
}