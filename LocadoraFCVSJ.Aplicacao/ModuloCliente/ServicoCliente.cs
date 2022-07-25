using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;
        private string _msgErro = "";

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente...");

            Result resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o cliente {cliente.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioCliente.Inserir(cliente);

                Log.Logger.Information($"Cliente {cliente.Id} inserido com sucesso!");

                return Result.Ok(cliente);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir cliente.";

                Log.Logger.Fatal(ex, _msgErro + $" {cliente.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente...");

            Result resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o cliente {cliente.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioCliente.Editar(cliente);

                Log.Logger.Information($"Cliente {cliente.Id} editado com sucesso!");

                return Result.Ok(cliente);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar cliente.";

                Log.Logger.Fatal(ex, _msgErro + $" {cliente.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Cliente> Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir cliente...");

            try
            {
                _repositorioCliente.Excluir(cliente);

                Log.Logger.Information($"Cliente {cliente.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (ExcluirRegistroRelacionadoException ex)
            {
                _msgErro = "Este cliente possui relação com alguma entidade no sistema e não pode ser excluído.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }

            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir cliente.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<Cliente>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioCliente.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todos os clientes.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<Cliente?> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(_repositorioCliente.SelecionarPorId(id));
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar selecionar o cliente.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        private Result Validar(Cliente cliente)
        {
            AbstractValidator<Cliente> validador = new ValidadorCliente();

            ValidationResult resultadoValidacao = validador.Validate(cliente);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (CpfDuplicado(cliente))
                erros.Add(new("CPF informado já existe."));

            if (CNPJDuplicado(cliente))
                erros.Add(new("CNPJ informado já existe."));

            if (CNHDuplicado(cliente))
                erros.Add(new("CNH informado já existe."));

            if (EmailDuplicado(cliente))
                erros.Add(new("Email informado já existe."));

            if (TelefoneDuplicado(cliente))
                erros.Add(new("Telefone informado já existe."));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool CpfDuplicado(Cliente cliente)
        {
            string query = @"SELECT 
                    CLIENTE.[ID] AS CLIENTE_ID,		            
                    CLIENTE.[NOME] AS CLIENTE_NOME,       
                    CLIENTE.[CPF] AS CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CLIENTE_CNPJ,                  
                    CLIENTE.[CNH] AS CLIENTE_CNH,                                                           
                    CLIENTE.[TELEFONE] AS CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CLIENTE_CEP,
                    CLIENTE.[RUA] AS CLIENTE_RUA,
                    CLIENTE.[NUMERO] AS CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CLIENTE_COMPLEMENTO
	            FROM 
		            [TBCLIENTE] AS CLIENTE
		        WHERE 
                    CLIENTE.[CPF] = @CPF";

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "CPF", cliente.CPF);

            return clienteEncontrado != null
                && clienteEncontrado.CPF.Equals(cliente.CPF, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }

        private bool CNPJDuplicado(Cliente cliente)
        {
            if (cliente.CNPJ != null)
            {
                string query = @"SELECT 
                    CLIENTE.[ID] AS CLIENTE_ID,		            
                    CLIENTE.[NOME] AS CLIENTE_NOME,       
                    CLIENTE.[CPF] AS CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CLIENTE_CNPJ,                  
                    CLIENTE.[CNH] AS CLIENTE_CNH,                                                           
                    CLIENTE.[TELEFONE] AS CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CLIENTE_CEP,
                    CLIENTE.[RUA] AS CLIENTE_RUA,
                    CLIENTE.[NUMERO] AS CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CLIENTE_COMPLEMENTO
	            FROM 
		            [TBCLIENTE] AS CLIENTE
		        WHERE 
                    CLIENTE.[CNPJ] = @CNPJ";

                Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "CNPJ", cliente.CNPJ);

                return clienteEncontrado != null
                    && clienteEncontrado.CNPJ.Equals(cliente.CNPJ, StringComparison.OrdinalIgnoreCase)
                    && clienteEncontrado.Id != cliente.Id;
            }
            return false;
        }

        private bool CNHDuplicado(Cliente cliente)
        {
            string query = @"SELECT 
                    CLIENTE.[ID] AS CLIENTE_ID,		            
                    CLIENTE.[NOME] AS CLIENTE_NOME,       
                    CLIENTE.[CPF] AS CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CLIENTE_CNPJ,                  
                    CLIENTE.[CNH] AS CLIENTE_CNH,                                                           
                    CLIENTE.[TELEFONE] AS CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CLIENTE_CEP,
                    CLIENTE.[RUA] AS CLIENTE_RUA,
                    CLIENTE.[NUMERO] AS CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CLIENTE_COMPLEMENTO
	            FROM 
		            [TBCLIENTE] AS CLIENTE
		        WHERE 
                    CLIENTE.[CNH] = @CNH";

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "CNH", cliente.CNH);

            return clienteEncontrado != null
                && clienteEncontrado.CNH.Equals(cliente.CNH, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }

        private bool EmailDuplicado(Cliente cliente)
        {
            string query = @"SELECT 
                    CLIENTE.[ID] AS CLIENTE_ID,		            
                    CLIENTE.[NOME] AS CLIENTE_NOME,       
                    CLIENTE.[CPF] AS CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CLIENTE_CNPJ,                  
                    CLIENTE.[CNH] AS CLIENTE_CNH,                                                           
                    CLIENTE.[TELEFONE] AS CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CLIENTE_CEP,
                    CLIENTE.[RUA] AS CLIENTE_RUA,
                    CLIENTE.[NUMERO] AS CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CLIENTE_COMPLEMENTO
	            FROM 
		            [TBCLIENTE] AS CLIENTE
		        WHERE 
                    CLIENTE.[EMAIL] = @EMAIL";

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "EMAIL", cliente.Email);

            return clienteEncontrado != null
                && clienteEncontrado.Email.Equals(cliente.Email, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }

        private bool TelefoneDuplicado(Cliente cliente)
        {
            string query = @"SELECT 
                    CLIENTE.[ID] AS CLIENTE_ID,		            
                    CLIENTE.[NOME] AS CLIENTE_NOME,       
                    CLIENTE.[CPF] AS CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CLIENTE_CNPJ,                  
                    CLIENTE.[CNH] AS CLIENTE_CNH,                                                           
                    CLIENTE.[TELEFONE] AS CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CLIENTE_CEP,
                    CLIENTE.[RUA] AS CLIENTE_RUA,
                    CLIENTE.[NUMERO] AS CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CLIENTE_COMPLEMENTO
	            FROM 
		            [TBCLIENTE] AS CLIENTE
		        WHERE 
                    CLIENTE.[TELEFONE] = @TELEFONE";

            Cliente? clienteEncontrado = _repositorioCliente.SelecionarPropriedade(query, "TELEFONE", cliente.Telefone);

            return clienteEncontrado != null
                && clienteEncontrado.Telefone.Equals(cliente.Telefone, StringComparison.OrdinalIgnoreCase)
                && clienteEncontrado.Id != cliente.Id;
        }

    }
}