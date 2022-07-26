using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.Compartilhado.Excecoes;
using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using Serilog;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloGrupo
{
    public class ServicoGrupo
    {
        private readonly IRepositorioGrupo _repositorioGrupo;
        private readonly IContextoPersistencia _contextoPersistencia;
        private string _msgErro = "";

        public ServicoGrupo(IRepositorioGrupo repositorioGrupo, IContextoPersistencia contextoPersistencia)
        {
            _repositorioGrupo = repositorioGrupo;
            _contextoPersistencia = contextoPersistencia;
        }

        public Result<Grupo> Inserir(Grupo grupo)
        {
            Log.Logger.Debug("Tentando inserir grupo...");

            Result resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o grupo {grupo.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioGrupo.Inserir(grupo);
                _contextoPersistencia.GravarDados();

                Log.Logger.Information($"Grupo {grupo.Id} inserido com sucesso!");

                return Result.Ok(grupo);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir grupo.";

                Log.Logger.Fatal(ex, _msgErro + $" {grupo.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Grupo> Editar(Grupo grupo)
        {
            Log.Logger.Debug("Tentando editar grupo...");

            Result resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o grupo {grupo.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioGrupo.Editar(grupo);
                _contextoPersistencia.GravarDados();

                Log.Logger.Information($"Grupo {grupo.Id} editado com sucesso!");

                return Result.Ok(grupo);
            } 
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar grupo.";

                Log.Logger.Fatal(ex, _msgErro + $" {grupo.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Grupo> Excluir(Grupo grupo)
        {
            Log.Logger.Debug("Tentando excluir grupo...");

            try
            {
                _repositorioGrupo.Excluir(grupo);
                _contextoPersistencia.GravarDados();

                Log.Logger.Information($"Grupo {grupo.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (ExcluirRegistroRelacionadoException ex)
            {
                _msgErro = "Esse grupo possui relação com alguma entidade no sistema e não pode ser excluído.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }

            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir grupo.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<Grupo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioGrupo.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todos os grupos.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        private Result Validar(Grupo grupo)
        {
            AbstractValidator<Grupo> validador = new ValidadorGrupo();

            ValidationResult resultadoValidacao = validador.Validate(grupo);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (NomeDuplicado(grupo))
                erros.Add(new("Nome informado já existe."));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Grupo grupo)
        {
            Grupo? grupoEncontrado = _repositorioGrupo.SelecionarGrupoPorNome(grupo.Nome);

            return grupoEncontrado != null
                && grupoEncontrado.Nome.Equals(grupo.Nome, StringComparison.OrdinalIgnoreCase)
                && grupoEncontrado.Id != grupo.Id;
        }
    }
}