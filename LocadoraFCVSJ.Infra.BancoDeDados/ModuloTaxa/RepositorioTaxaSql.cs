using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa
{
    public class RepositorioTaxaSql : RepositorioBase<Taxa, MapeadorTaxa>, IRepositorioTaxa
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBTaxa]
                (
                    [ID],
                    [NOME],
                    [VALOR],
                    [TIPOCALCULOTAXA]
                )
                VALUES
                (
                    @ID,
                    @NOME,
                    @VALOR,
                    @TIPOCALCULOTAXA
                )";

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
	                TAXA.[ID] AS TAXA_ID,
	                TAXA.[NOME] AS TAXA_NOME,
	                TAXA.[VALOR] AS TAXA_VALOR,
	                TAXA.[TIPOCALCULOTAXA] AS TAXA_TIPOCALCULO
                FROM
	                [TBTaxa] AS TAXA
                WHERE 
	                TAXA.[ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT 
	                TAXA.[ID] AS TAXA_ID,
	                TAXA.[NOME] AS TAXA_NOME,
	                TAXA.[VALOR] AS TAXA_VALOR,
	                TAXA.[TIPOCALCULOTAXA] AS TAXA_TIPOCALCULO
                FROM
	                [TBTaxa] AS TAXA";

        public Taxa? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }
    }
}