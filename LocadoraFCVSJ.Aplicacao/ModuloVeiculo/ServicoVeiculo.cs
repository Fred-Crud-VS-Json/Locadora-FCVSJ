using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;

namespace LocadoraFCVSJ.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private readonly RepositorioVeiculo repositorioVeiculo;

        public ServicoVeiculo(RepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Inserir(veiculo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Editar(veiculo);

            return resultadoValidacao;
        }

        public List<Veiculo> SelecionarTodos()
        {
            return repositorioVeiculo.SelecionarTodos();
        }

        public void SalvarVeiculo(Veiculo veiculo, string caminhoFoto)
        {
            veiculo.CaminhoFoto = caminhoFoto;
        }


        private ValidationResult Validar(Veiculo veiculo)
        {
            AbstractValidator<Veiculo> validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            if (NomeDuplicado(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Modelo", "Modelo informado já existe."));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Veiculo veiculo)
        {
            string query = repositorioVeiculo.QuerySelecionarPorModelo;

            Veiculo? veiculoEncontrado = repositorioVeiculo.SelecionarPropriedade(query, "MODELO", veiculo.Modelo);

            return veiculoEncontrado != null
                && veiculoEncontrado.Modelo.Equals(veiculo.Modelo, StringComparison.OrdinalIgnoreCase)
                && veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
