using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    [RUA]
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
                    @RUA

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
                        [RUA] = @RUA
                    WHERE 
                        [ID] = @ID";


        protected override string QueryExcluir => @"DELETE FROM [TBCONDUTOR] 
                WHERE [ID] = @ID";

        protected override string QuerySelecionarPorId => @"SELECT 
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
                    [RUA]
	            FROM 
		            [TBCONDUTOR]
		        WHERE
                    [ID] = @ID";

        protected override string QuerySelecionarTodos => @"SELECT 
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
                    [RUA]
	            FROM 
		            [TBCONDUTOR]";

        public string QuerySelecionarPorCpf =>
           @"SELECT 
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
                    [RUA]
	            FROM 
		            [TBCONDUTOR]
		        WHERE 
                    [CPF] = @CPF";

        public string QuerySelecionarPorCnpj =>
           @"SELECT 
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
                   [RUA]
	            FROM 
		            [TBCONDUTOR]
		        WHERE 
                    [CNPJ] = @CNPJ";

        public string QuerySelecionarPorTelefone =>
           @"SELECT 
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
                   [RUA]
	            FROM 
		            [TBCONDUTOR]
		        WHERE 
                    [TELEFONE] = @TELEFONE";

        public string QuerySelecionarPorEmail =>
           @"SELECT 
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
                    [RUA]
	            FROM 
		            [TBCONDUTOR]
		        WHERE 
                    [EMAIL] = @EMAIL";

        public string QuerySelecionarPorCnh =>
           @"SELECT 
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
                    [RUA]
	            FROM 
		            [TBCONDUTOR]
		        WHERE 
                    [CNH] = @CNH";

        public Condutor? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }
    }
}
