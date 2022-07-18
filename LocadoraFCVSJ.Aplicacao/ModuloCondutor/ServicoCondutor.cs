﻿using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;
using Serilog;

namespace LocadoraFCVSJ.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private readonly RepositorioCondutor _repositorioCondutor;
        private readonly ServicoCliente _servicoCliente;

        public ServicoCondutor(RepositorioCondutor repositorioCondutor, ServicoCliente servicoCliente)
        {
            _repositorioCondutor = repositorioCondutor;
            _servicoCliente = servicoCliente;
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir novo condutor...");

            ValidationResult resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                _repositorioCondutor.Inserir(condutor);
                Log.Logger.Information($"Condutor {condutor.Id} inserido com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o condutor {condutor.Id} - {erro.ErrorMessage}");
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar condutor...");

            ValidationResult resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                _repositorioCondutor.Editar(condutor);
                Log.Logger.Information($"Condutor {condutor.Id} editado com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o condutor {condutor.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public List<Cliente> SelecionarTodosOsClientes()
        {
            return _servicoCliente.SelecionarTodos().Value;
        }

        private ValidationResult Validar(Condutor condutor)
        {
            AbstractValidator<Condutor> validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            if (CpfDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF informado já existe."));

            if (CNPJDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNPJ", "CNPJ informado já existe."));

            if (CNHDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH informada já existe."));

            if (EmailDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Email", "Email informado já existe."));

            if (TelefoneDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Telefone", "Telefone informado já existe."));


            return resultadoValidacao;
        }

        private bool CpfDuplicado(Condutor condutor)
        {
            string query = _repositorioCondutor.QuerySelecionarPorCpf;

            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "CPF", condutor.CPF);

            return condutorEncontrado != null
                && condutorEncontrado.CPF.Equals(condutor.CPF, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool CNPJDuplicado(Condutor condutor)
        {
            if (condutor.CNPJ != null)
            {
                string query = _repositorioCondutor.QuerySelecionarPorCnpj;

                Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "CNPJ", condutor.CNPJ);

                return condutorEncontrado != null
                    && condutorEncontrado.CNPJ.Equals(condutor.CNPJ, StringComparison.OrdinalIgnoreCase)
                    && condutorEncontrado.Id != condutor.Id;
            }
            return false;
        }

        private bool CNHDuplicado(Condutor condutor)
        {
            string query = _repositorioCondutor.QuerySelecionarPorCnh;

            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "CNH", condutor.CNH);

            return condutorEncontrado != null
                && condutorEncontrado.CNH.Equals(condutor.CNH, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool EmailDuplicado(Condutor condutor)
        {
            string query = _repositorioCondutor.QuerySelecionarPorEmail;

            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "EMAIL", condutor.Email);

            return condutorEncontrado != null
                && condutorEncontrado.Email.Equals(condutor.Email, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool TelefoneDuplicado(Condutor condutor)
        {
            string query = _repositorioCondutor.QuerySelecionarPorTelefone;

            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "TELEFONE", condutor.Telefone);

            return condutorEncontrado != null
                && condutorEncontrado.Telefone.Equals(condutor.Telefone, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }
    }
}