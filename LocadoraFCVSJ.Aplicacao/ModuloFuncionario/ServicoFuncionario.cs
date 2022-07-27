using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.Compartilhado.Excecoes;
using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        private readonly IContextoPersistencia _contextoPersistencia;
        private string _msgErro = "";

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario, IContextoPersistencia contextoPersistencia)
        {
            _repositorioFuncionario = repositorioFuncionario;
            _contextoPersistencia = contextoPersistencia;
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
                _contextoPersistencia.GravarDados();

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
                _contextoPersistencia.GravarDados();

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
                _contextoPersistencia.GravarDados();

                Log.Logger.Information($"Funcionário {funcionario.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (ExcluirRegistroRelacionadoException ex)
            {
                _msgErro = "Esse funcionário possui relação com alguma entidade no sistema e não pode ser excluído.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
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

            if (UsuarioDuplicado(funcionario))
                erros.Add(new("Usuário informado já existe"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool UsuarioDuplicado(Funcionario funcionario)
        {
            Funcionario? funcionarioEncontrado = _repositorioFuncionario.SelecionarPorUsuario(funcionario.Nome);

            return funcionarioEncontrado != null
                && funcionarioEncontrado.Usuario.Equals(funcionario.Usuario, StringComparison.OrdinalIgnoreCase)
                && funcionarioEncontrado.Id != funcionario.Id;
        }
    }
}