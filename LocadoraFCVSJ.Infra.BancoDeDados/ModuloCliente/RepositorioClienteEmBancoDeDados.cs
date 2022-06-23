using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados : RepositorioBase<Cliente, ValidadorCliente, MapeadorCliente>
    {

        protected override string QueryInserir => @"INSERT INTO [TBCLIENTE]
                (
                    [NOME],       
                    [DADO], 
                    [ENDERECO],
                    [TIPO],                    
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL]
                )
            VALUES
                (
                    @NOME,
                    @DADO,
                    @ENDERECO,
                    @TIPO,
                    @CNH,
                    @TELEFONE,
                    @EMAIL
                ); SELECT SCOPE_IDENTITY();";

        protected override string QueryEditar => @" UPDATE [TBCLIENTE]
                    SET 
                        [NOME] = @NOME, 
                        [DADO] = @DADO, 
                        [ENDERECO] = @ENDERECO,
                        [TIPO] = @TIPO, 
                        [CNH] = @CNH,
                        [TELEFONE] = @TELEFONE,
                        [EMAIL] =  @EMAIL
                    WHERE [ID] = @ID";

        protected override string QueryExcluir => @"DELETE FROM [TBCLIENTE] 
                WHERE [ID] = @ID";

        protected override string QuerySelecionarPorId => @"SELECT 
                    [ID],		            
                    [NOME],       
                    [DADO], 
                    [ENDERECO],
                    [TIPO],                    
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL]
                    
	            FROM 
		            [TBCLIENTE]
		        WHERE
                    [ID] = @ID";

        protected override string QuerySelecionarTodos => @"SELECT 
                    [ID],
		            [NOME],       
                    [DADO], 
                    [ENDERECO],
                    [TIPO],                    
                    [CNH],                                                           
                    [TELEFONE],
                    [EMAIL]
	            FROM 
		            [TBCLIENTE]";
    }
}
