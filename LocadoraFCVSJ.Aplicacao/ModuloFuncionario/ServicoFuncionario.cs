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
                resultadoValidacao.Errors.Add(new ValidationFailure("Usuario", "Usuario informado já existe."));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            string query = repositorioFuncionario.QuerySelecionarPorUsuario;

            Funcionario? grupoEncontrado = repositorioFuncionario.SelecionarPropriedade(query, "USUARIO", funcionario.Usuario);

            return grupoEncontrado != null
                && grupoEncontrado.Nome.Equals(funcionario.Nome, StringComparison.OrdinalIgnoreCase)
                && grupoEncontrado.Id != funcionario.Id;
        }
    }
}