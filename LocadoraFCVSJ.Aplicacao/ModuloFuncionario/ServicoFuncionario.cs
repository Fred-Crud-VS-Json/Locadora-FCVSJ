using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using Serilog;

namespace LocadoraFCVSJ.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private readonly RepositorioFuncionario repositorioFuncionario;

        public ServicoFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public ValidationResult Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir novo funcionário...");

            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Inserir(funcionario);
                Log.Logger.Information($"Funcionário {funcionario.Id} inserido com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o funcionário {funcionario.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar funcionário...");

            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Editar(funcionario);
                Log.Logger.Information($"Funcionário {funcionario.Id} editado com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o funcionário {funcionario.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Funcionario funcionario)
        {
            AbstractValidator<Funcionario> validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Usuario informado já existe."));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            string query = repositorioFuncionario.QuerySelecionarPorUsuario;

            Funcionario? funcionarioEncontrado = repositorioFuncionario.SelecionarPropriedade(query, "LOGIN", funcionario.Usuario);

            return funcionarioEncontrado != null
                && funcionarioEncontrado.Usuario.Equals(funcionario.Usuario, StringComparison.OrdinalIgnoreCase)
                && funcionarioEncontrado.Id != funcionario.Id;
        }
    }
}