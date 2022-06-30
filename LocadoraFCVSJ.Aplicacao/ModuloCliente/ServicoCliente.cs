using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;

namespace LocadoraFCVSJ.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private readonly RepositorioCliente _repositorioCliente;

        public ServicoCliente(RepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                _repositorioCliente.Inserir(cliente);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                _repositorioCliente.Editar(cliente);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Cliente cliente)
        {
            AbstractValidator<Cliente> validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            if (CpfDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF informado já existe."));

            if (CNPJDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNPJ", "CNPJ informado já existe."));

            if (CNHDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH informada já existe."));

            if (EmailDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Email", "Email informado já existe."));

            if (TelefoneDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Telefone", "Telefone informado já existe."));


            return resultadoValidacao;
        }

        private bool CpfDuplicado(Cliente cliente)
        {
            string query = _repositorioCliente.QuerySelecionarPorCpf;

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "CPF", cliente.CPF);

            return clienteEncontrado != null
                && clienteEncontrado.CPF.Equals(cliente.CPF, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }

        private bool CNPJDuplicado(Cliente cliente)
        {
            string query = _repositorioCliente.QuerySelecionarPorCnpj;

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "CNPJ", cliente.CNPJ);

            return clienteEncontrado != null
                && clienteEncontrado.CNPJ.Equals(cliente.CNPJ, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }

        private bool CNHDuplicado(Cliente cliente)
        {
            string query = _repositorioCliente.QuerySelecionarPorCnh;

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "CNH", cliente.CNH);

            return clienteEncontrado != null
                && clienteEncontrado.CNH.Equals(cliente.CNH, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }

        private bool EmailDuplicado(Cliente cliente)
        {
            string query = _repositorioCliente.QuerySelecionarPorEmail;

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "EMAIL", cliente.Email);

            return clienteEncontrado != null
                && clienteEncontrado.Email.Equals(cliente.Email, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }

        private bool TelefoneDuplicado(Cliente cliente)
        {
            string query = _repositorioCliente.QuerySelecionarPorTelefone;

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "TELEFONE", cliente.Telefone);

            return clienteEncontrado != null
                && clienteEncontrado.Telefone.Equals(cliente.Telefone, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }
    }
}
