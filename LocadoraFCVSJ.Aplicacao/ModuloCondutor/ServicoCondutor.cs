using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Dominio.Compartilhado.Excecoes;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private readonly IRepositorioCondutor _repositorioCondutor;
        private readonly ServicoCliente _servicoCliente;
        private string _msgErro = "";

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, ServicoCliente servicoCliente)
        {
            _repositorioCondutor = repositorioCondutor;
            _servicoCliente = servicoCliente;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir condutor...");

            Result resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o condutor {condutor.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioCondutor.Inserir(condutor);

                Log.Logger.Information($"Condutor {condutor.Id} inserido com sucesso!");

                return Result.Ok(condutor);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir condutor.";

                Log.Logger.Fatal(ex, _msgErro + $" {condutor.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar condutor...");

            Result resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o condutor {condutor.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioCondutor.Editar(condutor);

                Log.Logger.Information($"Condutor {condutor.Id} editado com sucesso!");

                return Result.Ok(condutor);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar condutor.";

                Log.Logger.Fatal(ex, _msgErro + $" {condutor.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Condutor> Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir condutor...");

            try
            {
                _repositorioCondutor.Excluir(condutor);

                Log.Logger.Information($"Condutor {condutor.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (ExcluirRegistroRelacionadoException ex)
            {
                _msgErro = "Esse condutor possui relação com alguma entidade no sistema e não pode ser excluído.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }

            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir condutor.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioCondutor.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todos os condutores.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public List<Cliente> SelecionarTodosOsClientes()
        {
            return _servicoCliente.SelecionarTodos().Value;
        }

        public Result<Condutor?> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(_repositorioCondutor.SelecionarPorId(id));
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar selecionar o condutor.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        private Result Validar(Condutor condutor)
        {
            AbstractValidator<Condutor> validador = new ValidadorCondutor();

            ValidationResult resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (CpfDuplicado(condutor))
                erros.Add(new("CPF informado já existe."));

            if (CNPJDuplicado(condutor))
                erros.Add(new("CNPJ informado já existe."));

            if (EmailDuplicado(condutor))
                erros.Add(new("Email informado já existe."));

            if (TelefoneDuplicado(condutor))
                erros.Add(new("Telefone informado já existe."));

            if (CNHDuplicado(condutor))
                erros.Add(new("CNH informado já existe."));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool CpfDuplicado(Condutor condutor)
        {
            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPorCpf(condutor.CPF);

            return condutorEncontrado != null
                && condutorEncontrado.CPF.Equals(condutor.CPF, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool CNPJDuplicado(Condutor condutor)
        {
            if (condutor.CNPJ != null)
            {
                Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPorCpf(condutor.CNPJ);

                return condutorEncontrado != null
                    && condutorEncontrado.CNPJ.Equals(condutor.CNPJ, StringComparison.OrdinalIgnoreCase)
                    && condutorEncontrado.Id != condutor.Id;
            }
            return false;
        }

        private bool EmailDuplicado(Condutor condutor)
        {
            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPorCpf(condutor.Email);

            return condutorEncontrado != null
                && condutorEncontrado.Email.Equals(condutor.Email, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool TelefoneDuplicado(Condutor condutor)
        {
            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPorCpf(condutor.Telefone);

            return condutorEncontrado != null
                && condutorEncontrado.Telefone.Equals(condutor.Telefone, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool CNHDuplicado(Condutor condutor)
        {
            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPorCpf(condutor.CNH);

            return condutorEncontrado != null
                && condutorEncontrado.CNH.Equals(condutor.CNH, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }
    }
}