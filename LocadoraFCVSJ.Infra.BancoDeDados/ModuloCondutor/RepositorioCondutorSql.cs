using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor
{
    public class RepositorioCondutorSql : RepositorioBase<Condutor, MapeadorCondutor>, IRepositorioCondutor
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBCONDUTOR]
                (
                    [ID],
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
                    @ID,
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
                )";

        protected override string QueryEditar =>
            @" UPDATE [TBCONDUTOR]
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

        protected override string QueryExcluir =>
            @"DELETE FROM [TBCONDUTOR] 
                WHERE [ID] = @ID";

        protected override string QuerySelecionarPorId =>
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
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID";

        public Condutor? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }
    }
}