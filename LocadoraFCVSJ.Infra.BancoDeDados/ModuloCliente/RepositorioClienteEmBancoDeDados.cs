using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados : RepositorioBase<Cliente, ValidadorCliente, MapeadorCliente>
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
    }
}
