using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;

namespace LocadoraFCVSJ.Aplicacao.ModuloGrupo
{
    public class ServicoGrupo
    {
        private readonly IRepositorioGrupo repositorioGrupo;

        public ServicoGrupo(IRepositorioGrupo repositorioGrupo)
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
            Grupo? grupoEncontrado = repositorioGrupo.SelecionarPropriedade("NOME", grupo.Nome);

            return grupoEncontrado != null
                && grupoEncontrado.Nome.Equals(grupo.Nome, StringComparison.OrdinalIgnoreCase)
                && grupoEncontrado.Id != grupo.Id;
        }
    }
}