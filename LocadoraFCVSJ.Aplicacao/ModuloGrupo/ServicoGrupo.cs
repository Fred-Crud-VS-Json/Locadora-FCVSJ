using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using Serilog;

namespace LocadoraFCVSJ.Aplicacao.ModuloGrupo
{
    public class ServicoGrupo
    {
        private readonly RepositorioGrupo _repositorioGrupo;

        public ServicoGrupo(RepositorioGrupo repositorioGrupo)
        {
            _repositorioGrupo = repositorioGrupo;
        }

        public ValidationResult Inserir(Grupo grupo)
        {
            Log.Logger.Debug("Tentando inserir novo grupo...");

            ValidationResult resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsValid)
            {
                _repositorioGrupo.Inserir(grupo);
                Log.Logger.Information($"Grupo {grupo.Id} inserido com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o grupo {grupo.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Grupo grupo)
        {
            Log.Logger.Debug("Tentando editar grupo...");

            ValidationResult resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsValid)
            {
                _repositorioGrupo.Editar(grupo);
                Log.Logger.Information($"Grupo {grupo.Id} editado com sucesso.");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o grupo {grupo.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public List<Grupo> SelecionarTodos()
        {
            return _repositorioGrupo.SelecionarTodos();
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
            string query = _repositorioGrupo.QuerySelecionarPorNome;

            Grupo? grupoEncontrado = _repositorioGrupo.SelecionarPropriedade(query, "NOME", grupo.Nome);

            return grupoEncontrado != null
                && grupoEncontrado.Nome.Equals(grupo.Nome, StringComparison.OrdinalIgnoreCase)
                && grupoEncontrado.Id != grupo.Id;
        }
    }
}