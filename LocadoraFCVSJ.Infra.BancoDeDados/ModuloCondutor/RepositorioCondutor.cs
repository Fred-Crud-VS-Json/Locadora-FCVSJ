using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor
{
    public class RepositorioCondutor : RepositorioBase<Condutor, MapeadorCondutor>, IRepositorioCondutor
    {
        protected override string QueryInserir => @"INSERT INTO [TBCONDUTOR]
                (
                    [NOME],       
                    [CPF],
                    [CNPJ],                   
                    [CNH],      
                    [DATAVENCIMENTO],
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA],
                    [CLIENTE_ID]
                )
            VALUES
                (
                    @NOME,
                    @CPF,
                    @CNPJ,
                    @CNH,
                    @DATAVENCIMENTO,
                    @TELEFONE,
                    @EMAIL,
                    @CIDADE,
                    @CEP,
                    @NUMERO,
                    @BAIRRO,
                    @UF,
                    @COMPLEMENTO,
                    @RUA,
                    @CLIENTE_ID
                ); SELECT SCOPE_IDENTITY();";

        protected override string QueryEditar => @" UPDATE [TBCONDUTOR]
                    SET 
                        [NOME] = @NOME,  
                        [CPF] = @CPF,
                        [CNPJ] = @CNPJ,
                        [CNH] = @CNH,
                        [DATAVENCIMENTO] = @DATAVENCIMENTO,
                        [TELEFONE] = @TELEFONE,
                        [EMAIL] =  @EMAIL,
                        [CIDADE] = @CIDADE,
                        [CEP] = @CEP,
                        [NUMERO] = @NUMERO,
                        [BAIRRO] = @BAIRRO,
                        [UF] = @UF,
                        [COMPLEMENTO] = @COMPLEMENTO,
                        [RUA] = @RUA,
                        [CLIENTE_ID] = @CLIENTE_ID
                    WHERE 
                        [ID] = @ID";


        protected override string QueryExcluir => @"DELETE FROM [TBCONDUTOR] 
                WHERE [ID] = @ID";

        protected override string QuerySelecionarPorId => @"SELECT 
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
                    CONDUTOR.[CLIENTE_ID] AS CONDUTOR_CLIENTE_ID,
                    CLIENTE.[NOME] AS CONDUTOR_CLIENTE_NOME,       
                    CLIENTE.[CPF]  AS CONDUTOR_CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CONDUTOR_CLIENTE_CNPJ,                   
                    CLIENTE.[CNH] AS CONDUTOR_CLIENTE_CNH,                                                       
                    CLIENTE.[TELEFONE] AS CONDUTOR_CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CONDUTOR_CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CONDUTOR_CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CONDUTOR_CLIENTE_CEP,
                    CLIENTE.[NUMERO] AS CONDUTOR_CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CONDUTOR_CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CONDUTOR_CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CONDUTOR_CLIENTE_COMPLEMENTO,
                    CLIENTE.[RUA] AS CONDUTOR_CLIENTE_RUA
	            FROM 
		            [TBCONDUTOR] AS CONDUTOR LEFT JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[ID] = @ID";

        protected override string QuerySelecionarTodos => @"SELECT 
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
                    CONDUTOR.[CLIENTE_ID] AS CONDUTOR_CLIENTE_ID,
                    CLIENTE.[NOME] AS CONDUTOR_CLIENTE_NOME,       
                    CLIENTE.[CPF]  AS CONDUTOR_CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CONDUTOR_CLIENTE_CNPJ,                   
                    CLIENTE.[CNH] AS CONDUTOR_CLIENTE_CNH,                                                       
                    CLIENTE.[TELEFONE] AS CONDUTOR_CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CONDUTOR_CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CONDUTOR_CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CONDUTOR_CLIENTE_CEP,
                    CLIENTE.[NUMERO] AS CONDUTOR_CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CONDUTOR_CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CONDUTOR_CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CONDUTOR_CLIENTE_COMPLEMENTO,
                    CLIENTE.[RUA] AS CONDUTOR_CLIENTE_RUA
	            FROM 
		            [TBCONDUTOR] AS CONDUTOR LEFT JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID";

        public string QuerySelecionarPorCpf =>
           @"SELECT 
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
                    CONDUTOR.[CLIENTE_ID] AS CONDUTOR_CLIENTE_ID,
                    CLIENTE.[NOME] AS CONDUTOR_CLIENTE_NOME,       
                    CLIENTE.[CPF]  AS CONDUTOR_CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CONDUTOR_CLIENTE_CNPJ,                   
                    CLIENTE.[CNH] AS CONDUTOR_CLIENTE_CNH,                                                       
                    CLIENTE.[TELEFONE] AS CONDUTOR_CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CONDUTOR_CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CONDUTOR_CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CONDUTOR_CLIENTE_CEP,
                    CLIENTE.[NUMERO] AS CONDUTOR_CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CONDUTOR_CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CONDUTOR_CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CONDUTOR_CLIENTE_COMPLEMENTO,
                    CLIENTE.[RUA] AS CONDUTOR_CLIENTE_RUA
	            FROM 
		            [TBCONDUTOR] AS CONDUTOR LEFT JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[CPF] = @CPF";


        public string QuerySelecionarPorCnpj =>
           @"SELECT 
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
                    CONDUTOR.[CLIENTE_ID] AS CONDUTOR_CLIENTE_ID,
                    CLIENTE.[NOME] AS CONDUTOR_CLIENTE_NOME,       
                    CLIENTE.[CPF]  AS CONDUTOR_CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CONDUTOR_CLIENTE_CNPJ,                   
                    CLIENTE.[CNH] AS CONDUTOR_CLIENTE_CNH,                                                       
                    CLIENTE.[TELEFONE] AS CONDUTOR_CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CONDUTOR_CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CONDUTOR_CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CONDUTOR_CLIENTE_CEP,
                    CLIENTE.[NUMERO] AS CONDUTOR_CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CONDUTOR_CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CONDUTOR_CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CONDUTOR_CLIENTE_COMPLEMENTO,
                    CLIENTE.[RUA] AS CONDUTOR_CLIENTE_RUA
	            FROM 
		            [TBCONDUTOR] AS CONDUTOR LEFT JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[CNPJ] = @CNPJ";


        public string QuerySelecionarPorTelefone =>
           @"SELECT 
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
                    CONDUTOR.[CLIENTE_ID] AS CONDUTOR_CLIENTE_ID,
                    CLIENTE.[NOME] AS CONDUTOR_CLIENTE_NOME,       
                    CLIENTE.[CPF]  AS CONDUTOR_CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CONDUTOR_CLIENTE_CNPJ,                   
                    CLIENTE.[CNH] AS CONDUTOR_CLIENTE_CNH,                                                       
                    CLIENTE.[TELEFONE] AS CONDUTOR_CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CONDUTOR_CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CONDUTOR_CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CONDUTOR_CLIENTE_CEP,
                    CLIENTE.[NUMERO] AS CONDUTOR_CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CONDUTOR_CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CONDUTOR_CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CONDUTOR_CLIENTE_COMPLEMENTO,
                    CLIENTE.[RUA] AS CONDUTOR_CLIENTE_RUA
	            FROM 
		            [TBCONDUTOR] AS CONDUTOR LEFT JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[TELEFONE] = @TELEFONE";


        public string QuerySelecionarPorEmail =>
           @"SELECT 
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
                    CONDUTOR.[CLIENTE_ID] AS CONDUTOR_CLIENTE_ID,
                    CLIENTE.[NOME] AS CONDUTOR_CLIENTE_NOME,       
                    CLIENTE.[CPF]  AS CONDUTOR_CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CONDUTOR_CLIENTE_CNPJ,                   
                    CLIENTE.[CNH] AS CONDUTOR_CLIENTE_CNH,                                                       
                    CLIENTE.[TELEFONE] AS CONDUTOR_CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CONDUTOR_CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CONDUTOR_CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CONDUTOR_CLIENTE_CEP,
                    CLIENTE.[NUMERO] AS CONDUTOR_CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CONDUTOR_CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CONDUTOR_CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CONDUTOR_CLIENTE_COMPLEMENTO,
                    CLIENTE.[RUA] AS CONDUTOR_CLIENTE_RUA
	            FROM 
		            [TBCONDUTOR] AS CONDUTOR LEFT JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[EMAIL] = @EMAIL";


        public string QuerySelecionarPorCnh =>
           @"SELECT 
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
                    CONDUTOR.[CLIENTE_ID] AS CONDUTOR_CLIENTE_ID,
                    CLIENTE.[NOME] AS CONDUTOR_CLIENTE_NOME,       
                    CLIENTE.[CPF]  AS CONDUTOR_CLIENTE_CPF,
                    CLIENTE.[CNPJ] AS CONDUTOR_CLIENTE_CNPJ,                   
                    CLIENTE.[CNH] AS CONDUTOR_CLIENTE_CNH,                                                       
                    CLIENTE.[TELEFONE] AS CONDUTOR_CLIENTE_TELEFONE,
                    CLIENTE.[EMAIL] AS CONDUTOR_CLIENTE_EMAIL,
                    CLIENTE.[CIDADE] AS CONDUTOR_CLIENTE_CIDADE,
                    CLIENTE.[CEP] AS CONDUTOR_CLIENTE_CEP,
                    CLIENTE.[NUMERO] AS CONDUTOR_CLIENTE_NUMERO,
                    CLIENTE.[BAIRRO] AS CONDUTOR_CLIENTE_BAIRRO,
                    CLIENTE.[UF] AS CONDUTOR_CLIENTE_UF,
                    CLIENTE.[COMPLEMENTO] AS CONDUTOR_CLIENTE_COMPLEMENTO,
                    CLIENTE.[RUA] AS CONDUTOR_CLIENTE_RUA
	            FROM 
		            [TBCONDUTOR] AS CONDUTOR LEFT JOIN
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID
		        WHERE
                    CONDUTOR.[CNH] = @CNH";


        public Condutor? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }
    }
}
