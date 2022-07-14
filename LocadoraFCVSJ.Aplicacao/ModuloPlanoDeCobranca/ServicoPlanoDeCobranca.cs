﻿using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using Serilog;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private readonly RepositorioPlanoDeCobranca _repositorioPlanoDeCobranca;
        private string _msgErro = "";

        public ServicoPlanoDeCobranca(RepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
        {
            _repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando inserir plano de cobrança...");

            Result resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o plano de cobrança {planoDeCobranca.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

                Log.Logger.Information($"Plano de cobrança {planoDeCobranca.Id} inserido com sucesso!");

                return Result.Ok(planoDeCobranca);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir plano de cobrança.";

                Log.Logger.Fatal(ex, _msgErro + $" {planoDeCobranca.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<PlanoDeCobranca> Editar(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando editar plano de cobrança...");

            Result resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o plano de cobrança {planoDeCobranca.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioPlanoDeCobranca.Editar(planoDeCobranca);

                Log.Logger.Information($"Plano de cobrança {planoDeCobranca.Id} editado com sucesso!");

                return Result.Ok(planoDeCobranca);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar plano de cobrança.";

                Log.Logger.Fatal(ex, _msgErro + $" {planoDeCobranca.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<PlanoDeCobranca> Excluir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando excluir plano de cobrança...");

            try
            {
                _repositorioPlanoDeCobranca.Excluir(planoDeCobranca);

                Log.Logger.Information($"Plano de cobrança {planoDeCobranca.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir plano de cobrança.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioPlanoDeCobranca.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todos os planos de cobranças.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        private Result Validar(PlanoDeCobranca planoDeCobranca)
        {
            AbstractValidator<PlanoDeCobranca> validador = new ValidadorPlanoDeCobranca();

            ValidationResult resultadoValidacao = validador.Validate(planoDeCobranca);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
    }
}