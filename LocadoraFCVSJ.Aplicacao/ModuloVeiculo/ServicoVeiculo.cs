using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;
using Serilog;

namespace LocadoraFCVSJ.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private readonly RepositorioVeiculo _repositorioVeiculo;

        public ServicoVeiculo(RepositorioVeiculo repositorioVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            Log.Logger.Information("Tentando inserir novo veículo...");

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                _repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Information($"Veículo {veiculo.Id} inserido com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o veículo {veiculo.Id} - {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo...");

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                _repositorioVeiculo.Editar(veiculo);
                Log.Logger.Information($"Veículo {veiculo.Id} editado com sucesso!");
            }
            else
            {
                foreach (ValidationFailure? erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o veículo {veiculo.Id} = {erro.ErrorMessage}");
            }

            return resultadoValidacao;
        }

        public List<Veiculo> SelecionarTodos()
        {
            return _repositorioVeiculo.SelecionarTodos();
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
            string query = _repositorioVeiculo.QuerySelecionarPorModelo;

            Veiculo? veiculoEncontrado = _repositorioVeiculo.SelecionarPropriedade(query, "MODELO", veiculo.Modelo);

            return veiculoEncontrado != null
                && veiculoEncontrado.Modelo.Equals(veiculo.Modelo, StringComparison.OrdinalIgnoreCase)
                && veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
