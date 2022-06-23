using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo
{
    public class RepositorioGrupo : RepositorioBase<Grupo, ValidadorGrupo, MapeadorGrupo>
    {
        protected override string QueryInserir => 
            @"INSERT INTO [TBGrupo]
                (
                    [Nome]
                )
                VALUES
                (
                    @NOME
                )
                SELECT SCOPE_IDENTITY()";

        protected override string QueryEditar =>
            @"UPDATE [TBGrupo]
	            SET 
		            [Nome] = @NOME
	            WHERE
		            [ID] = @ID";

        protected override string QueryExcluir =>
            @"DELETE FROM [TBGrupo] 
                WHERE 
                    [ID] = @ID";

        protected override string QuerySelecionarPorId =>
            @"SELECT 
	                GRUPO.[ID],
	                GRUPO.[NOME]
                FROM
	                [TBGrupo] AS GRUPO
                WHERE 
	                GRUPO.[ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT 
	                GRUPO.[ID],
	                GRUPO.[NOME]
                FROM
	                [TBGrupo] AS GRUPO";
    }
}