using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;

namespace LocadoraFCVSJ.Aplicacao.ModuloGrupo
{
    public class ServicoGrupo
    {
        private readonly RepositorioGrupo repositorioGrupo;

        public ServicoGrupo(RepositorioGrupo repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }

        public ValidationResult Inserir(Grupo grupo)
        {
            ValidationResult resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsValid)
                repositorioGrupo.Inserir(grupo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Grupo grupo)
        {
            ValidationResult resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsValid)
                repositorioGrupo.Editar(grupo);

            return resultadoValidacao;
        }

        public List<Grupo> SelecionarTodos()
        {
            return repositorioGrupo.SelecionarTodos();
        }

        private ValidationResult Validar(Grupo grupo)
        {
            AbstractValidator<Grupo> validador = new ValidadorGrupo();

            var resultadoValidacao = validador.Validate(grupo);

            if (NomeDuplicado(grupo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome informado já existe."));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Grupo grupo)
        {
            string query = repositorioGrupo.QuerySelecionarPorNome;

            Grupo? grupoEncontrado = repositorioGrupo.SelecionarPropriedade(query, "NOME", grupo.Nome);

            return grupoEncontrado != null
                && grupoEncontrado.Nome.Equals(grupo.Nome, StringComparison.OrdinalIgnoreCase)
                && grupoEncontrado.Id != grupo.Id;
        }
    }
}