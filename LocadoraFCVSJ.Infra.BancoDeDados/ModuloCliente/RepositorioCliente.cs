using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente
{
    public class RepositorioCliente : RepositorioBase<Cliente, MapeadorCliente>, IRepositorioCliente
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

        public string QuerySelecionarPorCpf =>
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

        public string QuerySelecionarPorCnpj =>
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

        public string QuerySelecionarPorTelefone =>
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

        public string QuerySelecionarPorEmail =>
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

        public string QuerySelecionarPorCnh =>
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

        public Cliente? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }
    }
}