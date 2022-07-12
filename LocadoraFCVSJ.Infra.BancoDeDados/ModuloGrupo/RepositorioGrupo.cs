using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo
{
    public class RepositorioGrupo : RepositorioBase<Grupo, MapeadorGrupo>, IRepositorioGrupo
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBGrupo]
                (
                    [ID],
                    [NOME]
                )
                VALUES
                (
                    @ID,
                    @NOME
                )";

        protected override string QueryEditar =>
            @"UPDATE [TBGrupo]
	            SET 
		            [NOME] = @NOME
	            WHERE
		            [ID] = @ID";

        protected override string QueryExcluir =>
            @"DELETE FROM [TBGrupo] 
                WHERE 
                    [ID] = @ID";

        protected override string QuerySelecionarPorId =>
            @"SELECT 
	                GRUPO.[ID] AS GRUPO_ID,
	                GRUPO.[NOME] AS GRUPO_NOME
                FROM
	                [TBGrupo] AS GRUPO
                WHERE 
	                GRUPO.[ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT 
	                GRUPO.[ID] AS GRUPO_ID,
	                GRUPO.[NOME] AS GRUPO_NOME
                FROM
	                [TBGrupo] AS GRUPO";

        public string QuerySelecionarPorNome =>
            @"SELECT 
	                GRUPO.[ID] AS GRUPO_ID,
	                GRUPO.[NOME] AS GRUPO_NAME
                FROM
	                [TBGrupo] AS GRUPO
                WHERE 
	                GRUPO.[NOME] = @NOME";

        public Grupo? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }
    }
}