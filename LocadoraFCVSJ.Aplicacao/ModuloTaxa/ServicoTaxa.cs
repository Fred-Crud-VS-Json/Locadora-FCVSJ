using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;

namespace LocadoraFCVSJ.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa 
    {
        private readonly RepositorioTaxa _repositorioTaxa;

        public ServicoTaxa(RepositorioTaxa repositorioTaxa)
        {
            _repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                _repositorioTaxa.Inserir(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                _repositorioTaxa.Editar(taxa);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            AbstractValidator<Taxa> validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (NomeDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome informado já existe."));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Taxa taxa)
        {
            string query = _repositorioTaxa.QuerySelecionarPorNome;

            Taxa? taxaEncontrada = _repositorioTaxa.SelecionarPropriedade(query, "NOME", taxa.Nome);

            return taxaEncontrada != null
                && taxaEncontrada.Nome.Equals(taxa.Nome, StringComparison.OrdinalIgnoreCase)
                && taxaEncontrada.Id != taxa.Id;
        }
    }
}