using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;
using Serilog;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private readonly IRepositorioCondutor _repositorioCondutor;
        private readonly ServicoCliente _servicoCliente;
        private string _msgErro = "";

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, ServicoCliente servicoCliente)
        {
            _repositorioCondutor = repositorioCondutor;
            _servicoCliente = servicoCliente;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir condutor...");

            Result resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar inserir o condutor {condutor.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioCondutor.Inserir(condutor);

                Log.Logger.Information($"Condutor {condutor.Id} inserido com sucesso!");

                return Result.Ok(condutor);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar inserir condutor.";

                Log.Logger.Fatal(ex, _msgErro + $" {condutor.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar condutor...");

            Result resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                    Log.Logger.Warning($"Falha ao tentar editar o condutor {condutor.Id} - {erro.Message}");

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioCondutor.Editar(condutor);

                Log.Logger.Information($"Condutor {condutor.Id} editado com sucesso!");

                return Result.Ok(condutor);
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar editar condutor.";

                Log.Logger.Fatal(ex, _msgErro + $" {condutor.Id}");

                return Result.Fail(_msgErro);
            }
        }

        public Result<Condutor> Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir condutor...");

            try
            {
                _repositorioCondutor.Excluir(condutor);

                Log.Logger.Information($"Condutor {condutor.Id} excluído com sucesso!");

                return Result.Ok();
            }
            catch (ExcluirRegistroRelacionadoException ex)
            {
                _msgErro = "Esse condutor possui relação com alguma entidade no sistema e não pode ser excluído.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }

            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar excluir condutor.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioCondutor.SelecionarTodos());
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao selecionar todos os condutores.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        public Result<Condutor?> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(_repositorioCondutor.SelecionarPorId(id));
            }
            catch (SqlException ex)
            {
                _msgErro = "Falha ao tentar selecionar o condutor.";

                Log.Logger.Fatal(ex, _msgErro);

                return Result.Fail(_msgErro);
            }
        }

        private Result Validar(Condutor condutor)
        {
            AbstractValidator<Condutor> validador = new ValidadorCondutor();

            ValidationResult resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new(erro.ErrorMessage));

            if (CpfDuplicado(condutor))
                erros.Add(new("CPF informado já existe."));

            if (CNPJDuplicado(condutor))
                erros.Add(new("CNPJ informado já existe."));

            if (CNHDuplicado(condutor))
                erros.Add(new("CNH informado já existe."));

            if (EmailDuplicado(condutor))
                erros.Add(new("Email informado já existe."));

            if (TelefoneDuplicado(condutor))
                erros.Add(new("Telefone informado já existe."));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        public List<Cliente> SelecionarTodosOsClientes()
        {
            return _servicoCliente.SelecionarTodos().Value;
        }

        private bool CpfDuplicado(Condutor condutor)
        {
            string query = @"SELECT 
	                CONDUTOR.[ID] AS CONDUTOR_ID,		            
                    CONDUTOR.[NOME] AS CONDUTOR_NOME,       
                    CONDUTOR.[CPF] AS CONDUTOR_CPF,
                    CONDUTOR.[CNPJ] AS CONDUTOR_CNPJ,                   
                    CONDUTOR.[CNH] AS CONDUTOR_CNH,      
                    CONDUTOR.[DATAVENCIMENTO] AS CONDUTOR_DATAVENCIMENTO,
                    CONDUTOR.[TELEFONE] AS CONDUTOR_TELEFONE,
                    CONDUTOR.[EMAIL] AS CONDUTOR_EMAIL,
                    CONDUTOR.[CIDADE] AS CONDUTOR_CIDADE,
                    CONDUTOR.[CEP] AS CONDUTOR_CEP,
                    CONDUTOR.[NUMERO] AS CONDUTOR_NUMERO,
                    CONDUTOR.[BAIRRO] AS CONDUTOR_BAIRRO,
                    CONDUTOR.[UF] AS CONDUTOR_UF,
                    CONDUTOR.[COMPLEMENTO] AS CONDUTOR_COMPLEMENTO,
                    CONDUTOR.[RUA] AS CONDUTOR_RUA,

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
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[CPF] = @CPF";

            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "CPF", condutor.CPF);

            return condutorEncontrado != null
                && condutorEncontrado.CPF.Equals(condutor.CPF, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool CNPJDuplicado(Condutor condutor)
        {
            if (condutor.CNPJ != null)
            {
                string query = @"SELECT 
	                CONDUTOR.[ID] AS CONDUTOR_ID,		            
                    CONDUTOR.[NOME] AS CONDUTOR_NOME,       
                    CONDUTOR.[CPF] AS CONDUTOR_CPF,
                    CONDUTOR.[CNPJ] AS CONDUTOR_CNPJ,                   
                    CONDUTOR.[CNH] AS CONDUTOR_CNH,      
                    CONDUTOR.[DATAVENCIMENTO] AS CONDUTOR_DATAVENCIMENTO,
                    CONDUTOR.[TELEFONE] AS CONDUTOR_TELEFONE,
                    CONDUTOR.[EMAIL] AS CONDUTOR_EMAIL,
                    CONDUTOR.[CIDADE] AS CONDUTOR_CIDADE,
                    CONDUTOR.[CEP] AS CONDUTOR_CEP,
                    CONDUTOR.[NUMERO] AS CONDUTOR_NUMERO,
                    CONDUTOR.[BAIRRO] AS CONDUTOR_BAIRRO,
                    CONDUTOR.[UF] AS CONDUTOR_UF,
                    CONDUTOR.[COMPLEMENTO] AS CONDUTOR_COMPLEMENTO,
                    CONDUTOR.[RUA] AS CONDUTOR_RUA,

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
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[CNPJ] = @CNPJ";

                Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "CNPJ", condutor.CNPJ);

                return condutorEncontrado != null
                    && condutorEncontrado.CNPJ.Equals(condutor.CNPJ, StringComparison.OrdinalIgnoreCase)
                    && condutorEncontrado.Id != condutor.Id;
            }
            return false;
        }

        private bool CNHDuplicado(Condutor condutor)
        {
            string query = @"SELECT 
	                CONDUTOR.[ID] AS CONDUTOR_ID,		            
                    CONDUTOR.[NOME] AS CONDUTOR_NOME,       
                    CONDUTOR.[CPF] AS CONDUTOR_CPF,
                    CONDUTOR.[CNPJ] AS CONDUTOR_CNPJ,                   
                    CONDUTOR.[CNH] AS CONDUTOR_CNH,      
                    CONDUTOR.[DATAVENCIMENTO] AS CONDUTOR_DATAVENCIMENTO,
                    CONDUTOR.[TELEFONE] AS CONDUTOR_TELEFONE,
                    CONDUTOR.[EMAIL] AS CONDUTOR_EMAIL,
                    CONDUTOR.[CIDADE] AS CONDUTOR_CIDADE,
                    CONDUTOR.[CEP] AS CONDUTOR_CEP,
                    CONDUTOR.[NUMERO] AS CONDUTOR_NUMERO,
                    CONDUTOR.[BAIRRO] AS CONDUTOR_BAIRRO,
                    CONDUTOR.[UF] AS CONDUTOR_UF,
                    CONDUTOR.[COMPLEMENTO] AS CONDUTOR_COMPLEMENTO,
                    CONDUTOR.[RUA] AS CONDUTOR_RUA,

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
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[CNH] = @CNH";

            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "CNH", condutor.CNH);

            return condutorEncontrado != null
                && condutorEncontrado.CNH.Equals(condutor.CNH, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool EmailDuplicado(Condutor condutor)
        {
            string query = @"SELECT 
	                CONDUTOR.[ID] AS CONDUTOR_ID,		            
                    CONDUTOR.[NOME] AS CONDUTOR_NOME,       
                    CONDUTOR.[CPF] AS CONDUTOR_CPF,
                    CONDUTOR.[CNPJ] AS CONDUTOR_CNPJ,                   
                    CONDUTOR.[CNH] AS CONDUTOR_CNH,      
                    CONDUTOR.[DATAVENCIMENTO] AS CONDUTOR_DATAVENCIMENTO,
                    CONDUTOR.[TELEFONE] AS CONDUTOR_TELEFONE,
                    CONDUTOR.[EMAIL] AS CONDUTOR_EMAIL,
                    CONDUTOR.[CIDADE] AS CONDUTOR_CIDADE,
                    CONDUTOR.[CEP] AS CONDUTOR_CEP,
                    CONDUTOR.[NUMERO] AS CONDUTOR_NUMERO,
                    CONDUTOR.[BAIRRO] AS CONDUTOR_BAIRRO,
                    CONDUTOR.[UF] AS CONDUTOR_UF,
                    CONDUTOR.[COMPLEMENTO] AS CONDUTOR_COMPLEMENTO,
                    CONDUTOR.[RUA] AS CONDUTOR_RUA,

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
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[EMAIL] = @EMAIL";

            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "EMAIL", condutor.Email);

            return condutorEncontrado != null
                && condutorEncontrado.Email.Equals(condutor.Email, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }

        private bool TelefoneDuplicado(Condutor condutor)
        {
            string query = @"SELECT 
	                CONDUTOR.[ID] AS CONDUTOR_ID,		            
                    CONDUTOR.[NOME] AS CONDUTOR_NOME,       
                    CONDUTOR.[CPF] AS CONDUTOR_CPF,
                    CONDUTOR.[CNPJ] AS CONDUTOR_CNPJ,                   
                    CONDUTOR.[CNH] AS CONDUTOR_CNH,      
                    CONDUTOR.[DATAVENCIMENTO] AS CONDUTOR_DATAVENCIMENTO,
                    CONDUTOR.[TELEFONE] AS CONDUTOR_TELEFONE,
                    CONDUTOR.[EMAIL] AS CONDUTOR_EMAIL,
                    CONDUTOR.[CIDADE] AS CONDUTOR_CIDADE,
                    CONDUTOR.[CEP] AS CONDUTOR_CEP,
                    CONDUTOR.[NUMERO] AS CONDUTOR_NUMERO,
                    CONDUTOR.[BAIRRO] AS CONDUTOR_BAIRRO,
                    CONDUTOR.[UF] AS CONDUTOR_UF,
                    CONDUTOR.[COMPLEMENTO] AS CONDUTOR_COMPLEMENTO,
                    CONDUTOR.[RUA] AS CONDUTOR_RUA,

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
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[TELEFONE] = @TELEFONE";

            Condutor? condutorEncontrado = _repositorioCondutor.SelecionarPropriedade(query, "TELEFONE", condutor.Telefone);

            return condutorEncontrado != null
                && condutorEncontrado.Telefone.Equals(condutor.Telefone, StringComparison.OrdinalIgnoreCase)
                && condutorEncontrado.Id != condutor.Id;
        }
    }
}