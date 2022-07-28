using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.Compartilhado.Excecoes;
using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloLocacao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraFCVSJ.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        private readonly IRepositorioLocacao _repositorioLocacao;
        private readonly IContextoPersistencia _contextoPersistencia;
        private string _msgErro = "";

        public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IContextoPersistencia contextoPersistencia)
        {
            _repositorioLocacao = repositorioLocacao;
            _contextoPersistencia = contextoPersistencia;
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando inserir locacao...");

            Result resultadoValidacao = Validar(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir a locação {locacao.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioLocacao.Inserir(locacao);
                _contextoPersistencia.GravarDados();

                Log.Logger.Information($"Locação {locacao.Id} inserida com sucesso!");

                return Result.Ok(locacao);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir locação.";

                Log.Logger.Fatal(ex, _msgErro + $" {locacao.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao locacao)
        {
            Log.Logger.Debug("Tentando editar grupo...");

            Result resultadoValidacao = Validar(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o locação {locacao.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioLocacao.Editar(locacao);
                _contextoPersistencia.GravarDados();

                Log.Logger.Information($"Locação {locacao.Id} editado com sucesso!");

                return Result.Ok(locacao);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar locação.";

                Log.Logger.Fatal(ex, _msgErro + $" {locacao.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Locacao> Excluir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando excluir locação...");

            try
            {
                _repositorioLocacao.Excluir(locacao);
                _contextoPersistencia.GravarDados();

                Log.Logger.Information($"Locação {locacao.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (ExcluirRegistroRelacionadoException ex)
            {
                _msgErro = "Essa locação possui relação com alguma entidade no sistema e não pode ser excluído.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }

            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir locação.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioLocacao.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todas as locações.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }
        private Result Validar(Locacao locacao)
        {
            AbstractValidator<Locacao> validador = new ValidadorLocacao();

            ValidationResult resultadoValidacao = validador.Validate(locacao);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
    }
}
