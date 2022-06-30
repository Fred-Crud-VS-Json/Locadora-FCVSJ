using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;

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
            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Inserir(funcionario);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Editar(funcionario);

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