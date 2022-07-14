using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private readonly RepositorioFuncionario _repositorioFuncionario;
        private string _msgErro = "";

        public ServicoFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario;
        }

        public Result<Funcionario> Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir funcionário...");

            Result resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o funcionário {funcionario.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioFuncionario.Inserir(funcionario);

                Log.Logger.Information($"Funcionário {funcionario.Id} inserido com sucesso!");

                return Result.Ok(funcionario);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir funcionário.";

                Log.Logger.Fatal(ex, _msgErro + $"{funcionario.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Funcionario> Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar funcionário...");

            Result resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o funcionário {funcionario.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioFuncionario.Editar(funcionario);

                Log.Logger.Information($"Funcionário {funcionario.Id} editado com sucesso!");

                return Result.Ok(funcionario);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar funcionário.";

                Log.Logger.Fatal(ex, _msgErro + $" {funcionario.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Funcionario> Excluir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando exlcluir funcionário...");

            try
            {
                _repositorioFuncionario.Excluir(funcionario);

                Log.Logger.Information($"Funcionário {funcionario.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir funcionário.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<Funcionario>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioFuncionario.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todos os funcionários.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

       
        private Result Validar(Funcionario funcionario)
        {
            AbstractValidator<Funcionario> validador = new ValidadorFuncionario();

            ValidationResult resultadoValidacao = validador.Validate(funcionario);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (NomeDuplicado(funcionario))
                erros.Add(new("Nome informado já existe"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            string query = _repositorioFuncionario.QuerySelecionarPorUsuario;

            Funcionario? funcionarioEncontrado = _repositorioFuncionario.SelecionarPropriedade(query, "LOGIN", funcionario.Usuario);

            return funcionarioEncontrado != null
                && funcionarioEncontrado.Usuario.Equals(funcionario.Usuario, StringComparison.OrdinalIgnoreCase)
                && funcionarioEncontrado.Id != funcionario.Id;
        }
    }
}