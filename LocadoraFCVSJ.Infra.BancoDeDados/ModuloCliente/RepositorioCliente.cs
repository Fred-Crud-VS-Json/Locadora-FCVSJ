using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente
{
    public class RepositorioCliente : RepositorioBase<Cliente, MapeadorCliente>, IRepositorioCliente
    {

        protected override string QueryInserir => @"INSERT INTO [TBCLIENTE]
                (
                    [NOME],       
                    [CPF],
                    [CNPJ],                   
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA]
                )
            VALUES
                (
                    @NOME,
                    @CPF,
                    @CNPJ,
                    @CNH,
                    @TELEFONE,
                    @EMAIL,
                    @CIDADE,
                    @CEP,
                    @NUMERO,
                    @BAIRRO,
                    @UF,
                    @COMPLEMENTO,
                    @RUA

                ); SELECT SCOPE_IDENTITY();";

        protected override string QueryEditar => @" UPDATE [TBCLIENTE]
                    SET 
                        [NOME] = @NOME,  
                        [CPF] = @CPF,
                        [CNPJ] = @CNPJ,
                        [CNH] = @CNH,
                        [TELEFONE] = @TELEFONE,
                        [EMAIL] =  @EMAIL,
                        [CIDADE] = @CIDADE,
                        [CEP] = @CEP,
                        [NUMERO] = @NUMERO,
                        [BAIRRO] = @BAIRRO,
                        [UF] = @UF,
                        [COMPLEMENTO] = @COMPLEMENTO,
                        [RUA] = @RUA
                    WHERE 
                        [ID] = @ID";

        protected override string QueryExcluir => @"DELETE FROM [TBCLIENTE] 
                WHERE [ID] = @ID";

        protected override string QuerySelecionarPorId => @"SELECT 
                    [ID],		            
                    [NOME],       
                    [CPF],
                    [CNPJ],                  
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA]
	            FROM 
		            [TBCLIENTE]
		        WHERE
                    [ID] = @ID";

        protected override string QuerySelecionarTodos => @"SELECT 
                    [ID],
		            [NOME],       
                    [CPF],
                    [CNPJ],                 
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA]
	            FROM 
		            [TBCLIENTE]";

        public string QuerySelecionarPorCpf =>
            @"SELECT 
	                 [ID],		            
                    [NOME],       
                    [CPF],
                    [CNPJ],                  
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA]
	            FROM 
		            [TBCLIENTE]
		        WHERE 
                    [CPF] = @CPF";

        public string QuerySelecionarPorCnpj =>
           @"SELECT 
	                 [ID],		            
                    [NOME],       
                    [CPF],
                    [CNPJ],                  
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA]
	            FROM 
		            [TBCLIENTE]
		        WHERE 
                    [CNPJ] = @CNPJ";

        public string QuerySelecionarPorTelefone =>
           @"SELECT 
	                 [ID],		            
                    [NOME],       
                    [CPF],
                    [CNPJ],                  
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA]
	            FROM 
		            [TBCLIENTE]
		        WHERE 
                    [TELEFONE] = @TELEFONE";

        public string QuerySelecionarPorEmail =>
           @"SELECT 
	                 [ID],		            
                    [NOME],       
                    [CPF],
                    [CNPJ],                  
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA]
	            FROM 
		            [TBCLIENTE]
		        WHERE 
                    [EMAIL] = @EMAIL";

        public string QuerySelecionarPorCnh =>
           @"SELECT 
	                 [ID],		            
                    [NOME],       
                    [CPF],
                    [CNPJ],                  
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL],
                    [CIDADE],
                    [CEP],
                    [NUMERO],
                    [BAIRRO],
                    [UF],
                    [COMPLEMENTO],
                    [RUA]
	            FROM 
		            [TBCLIENTE]
		        WHERE 
                    [CNH] = @CNH";

        public Cliente? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }
    }
}
