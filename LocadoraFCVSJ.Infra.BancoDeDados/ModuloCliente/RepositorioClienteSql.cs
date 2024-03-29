﻿using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente
{
    public class RepositorioClienteSql : RepositorioBaseSql<Cliente, MapeadorCliente>, IRepositorioCliente
    {

        protected override string QueryInserir =>
            @"INSERT INTO [TBCliente]
                (
                    [ID],
                    [NOME],       
                    [CPF],
                    [CNPJ],                   
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [RUA],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO]
                )
            VALUES
                (
                    @ID,
                    @NOME,
                    @CPF,
                    @CNPJ,
                    @CNH,
                    @TELEFONE,
                    @EMAIL,
                    @CIDADE,
                    @CEP,
                    @RUA,
                    @NUMERO,
                    @BAIRRO,
                    @UF,
                    @COMPLEMENTO
                )";

        protected override string QueryEditar =>
            @" UPDATE [TBCliente]
                    SET 
                        [NOME] = @NOME,  
                        [CPF] = @CPF,
                        [CNPJ] = @CNPJ,
                        [CNH] = @CNH,
                        [TELEFONE] = @TELEFONE,
                        [EMAIL] =  @EMAIL,
                        [CIDADE] = @CIDADE,
                        [CEP] = @CEP,
                        [RUA] = @RUA,
                        [NUMERO] = @NUMERO,
                        [BAIRRO] = @BAIRRO,
                        [UF] = @UF,
                        [COMPLEMENTO] = @COMPLEMENTO
                    WHERE 
                        [ID] = @ID";

        protected override string QueryExcluir =>
            @"DELETE FROM [TBCliente] 
                WHERE [ID] = @ID";

        protected override string QuerySelecionarPorId =>
            @"SELECT 
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
                    CLIENTE.[ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT 
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
		            [TBCLIENTE] AS CLIENTE";

        private string QuerySelecionarPorCpf =>
            @"SELECT 
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

        private string QuerySelecionarPorCnpj =>
            @"SELECT 
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

        private string QuerySelecionarPorTelefone =>
            @"SELECT 
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

        private string QuerySelecionarPorEmail =>
            @"SELECT 
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

        private string QuerySelecionarPorCnh =>
            @"SELECT 
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

        public Cliente? SelecionarPorCpf(string cpf)
        {
            return SelecionarParametro(QuerySelecionarPorCpf, new SqlParameter("CPF", cpf));
        }

        public Cliente? SelecionarPorCnpj(string cnpj)
        {
            return SelecionarParametro(QuerySelecionarPorCnpj, new SqlParameter("CNPJ", cnpj));
        }

        public Cliente? SelecionarPorTelefone(string telefone)
        {
            return SelecionarParametro(QuerySelecionarPorTelefone, new SqlParameter("TELEFONE", telefone));
        }

        public Cliente? SelecionarPorEmail(string email)
        {
            return SelecionarParametro(QuerySelecionarPorEmail, new SqlParameter("EMAIL", email));
        }

        public Cliente? SelecionarPorCnh(string cnh)
        {
            return SelecionarParametro(QuerySelecionarPorCnh, new SqlParameter("CNH", cnh));
        }
    }
}