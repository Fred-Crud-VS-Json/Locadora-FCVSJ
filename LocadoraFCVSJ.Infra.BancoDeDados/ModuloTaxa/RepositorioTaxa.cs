using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa
{
    public class RepositorioTaxa : RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa>
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBTaxa]
                (
                    [NOME],
                    [VALOR],
                    [TIPOCALCULOTAXA]
                )
                VALUES
                (
                    @NOME,
                    @VALOR,
                    @TIPOCALCULOTAXA
                )
                SELECT SCOPE_IDENTITY()";

        protected override string QueryEditar =>
             @"UPDATE [TBTaxa]
	            SET 
                    [NOME] = @NOME,
                    [VALOR] = @VALOR,
                    [TIPOCALCULOTAXA] = @TIPOCALCULOTAXA
	            WHERE
		            [ID] = @ID";

        protected override string QueryExcluir =>
            @"DELETE FROM [TBTaxa] 
                WHERE 
                    [ID] = @ID";

        protected override string QuerySelecionarPorId =>
            @"SELECT 
	                TAXA.[ID],
	                TAXA.[NOME],
	                TAXA.[VALOR],
	                TAXA.[TIPOCALCULOTAXA]
                FROM
	                [TBTaxa] AS TAXA
                WHERE 
	                TAXA.[ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT 
	                TAXA.[ID],
	                TAXA.[NOME],
	                TAXA.[VALOR],
	                TAXA.[TIPOCALCULOTAXA]
                FROM
	                [TBTaxa] AS TAXA";
    }
}