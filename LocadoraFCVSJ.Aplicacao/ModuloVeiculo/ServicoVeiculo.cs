using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private readonly RepositorioVeiculo _repositorioVeiculo;
        private string _msgErro = "";

        public ServicoVeiculo(RepositorioVeiculo repositorioVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir veículo...");

            Result resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o veículo {veiculo.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioVeiculo.Inserir(veiculo);

                Log.Logger.Information($"Veículo {veiculo.Id} inserido com sucesso!");

                return Result.Ok(veiculo);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir veículo.";

                Log.Logger.Fatal(ex, _msgErro + $"{veiculo.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo...");

            Result resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o veículo {veiculo.Id} = {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioVeiculo.Editar(veiculo);

                Log.Logger.Information($"Veículo {veiculo.Id} editado com sucesso!");

                return Result.Ok(veiculo);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar veículo.";

                Log.Logger.Fatal(ex, _msgErro + $"{veiculo.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Veiculo> Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando exlcluir funcionário...");

            try
            {
                _repositorioVeiculo.Excluir(veiculo);

                Log.Logger.Information($"Veículo {veiculo.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (ExcluirRegistroRelacionadoException ex)
            {
                _msgErro = "Esse veículo possui relação com alguma outra entidade no sistema e não pode ser excluído.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }

            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir veículo.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioVeiculo.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todos os veículo.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        private Result Validar(Veiculo veiculo)
        {
            AbstractValidator<Veiculo> validador = new ValidadorVeiculo();

            ValidationResult resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (NomeDuplicado(veiculo))
                erros.Add(new("Nome informado já existe"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Veiculo veiculo)
        {
            string query = _repositorioVeiculo.QuerySelecionarPorModelo;

            Veiculo? veiculoEncontrado = _repositorioVeiculo.SelecionarPropriedade(query, "MODELO", veiculo.Modelo);

            return veiculoEncontrado != null
                && veiculoEncontrado.Modelo.Equals(veiculo.Modelo, StringComparison.OrdinalIgnoreCase)
                && veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
