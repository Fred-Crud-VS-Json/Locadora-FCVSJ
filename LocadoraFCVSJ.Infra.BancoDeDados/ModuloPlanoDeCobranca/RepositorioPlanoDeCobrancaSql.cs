using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaSql : RepositorioBase<PlanoDeCobranca, MapeadorPlanoDeCobranca>, IRepositorioPlanoDeCobranca
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBPlanoDeCobranca]
                (
					[ID],
		            [PLANODIARIO_VALORDIARIO],
                    [PLANODIARIO_VALORKM],
		            [PLANOLIVRE_VALORDIARIO],
                    [PLANOCONTROLADO_VALORDIARIO],
                    [PLANOCONTROLADO_VALORKM],
                    [PLANOCONTROLADO_LIMITEKM],
                    [GRUPO_ID]
	            )
                 VALUES
                (
					@ID,
		            @PLANODIARIO_VALORDIARIO,
		            @PLANODIARIO_VALORKM,
		            @PLANOLIVRE_VALORDIARIO,
		            @PLANOCONTROLADO_VALORDIARIO,
		            @PLANOCONTROLADO_VALORKM,
		            @PLANOCONTROLADO_LIMITEKM,
		            @GRUPO_ID
	            )";

        protected override string QueryEditar =>
            @"UPDATE [TBPlanoDeCobranca]
	            SET
		            [PLANODIARIO_VALORDIARIO] =	@PLANODIARIO_VALORDIARIO,
                    [PLANODIARIO_VALORKM] = @PLANODIARIO_VALORKM,
		            [PLANOLIVRE_VALORDIARIO] = @PLANOLIVRE_VALORDIARIO,
                    [PLANOCONTROLADO_VALORDIARIO] = @PLANOCONTROLADO_VALORDIARIO,
                    [PLANOCONTROLADO_VALORKM] = @PLANOCONTROLADO_VALORKM,
                    [PLANOCONTROLADO_LIMITEKM] = @PLANOCONTROLADO_LIMITEKM,
                    [GRUPO_ID] = @GRUPO_ID
	            WHERE
		            [ID] = @ID";

        protected override string QueryExcluir => 
            @"DELETE FROM [TBPlanoDeCobranca]
                WHERE
                    [ID] = @ID";

        protected override string QuerySelecionarPorId =>
			@"SELECT
					PLANO.[ID] AS PLANO_ID,
					PLANO.[PLANODIARIO_VALORDIARIO] AS PLANO_DIARIO_VALORDIARIO,
					PLANO.[PLANODIARIO_VALORKM] AS PLANO_DIARIO_VALORKM,
					PLANO.[PLANOLIVRE_VALORDIARIO] AS PLANO_LIVRE_VALORDIARIO,
					PLANO.[PLANOCONTROLADO_VALORDIARIO] AS PLANO_CONTROLADO_VALORDIARIO,
					PLANO.[PLANOCONTROLADO_VALORKM] AS PLANO_CONTROLADO_VALORKM,
					PLANO.[PLANOCONTROLADO_LIMITEKM] AS PLANO_CONTROLADO_LIMITEKM,

					GRUPO.[ID] AS GRUPO_ID,
					GRUPO.[NOME] AS GRUPO_NOME
				FROM 
					[TBPlanoDeCobranca] AS PLANO

					INNER JOIN

					[TBGrupo] AS GRUPO

					ON PLANO.[GRUPO_ID] = GRUPO.[ID]

				WHERE
					PLANO.[ID] = @ID";

		protected override string QuerySelecionarTodos =>
			@"SELECT
					PLANO.[ID] AS PLANO_ID,
					PLANO.[PLANODIARIO_VALORDIARIO] AS PLANO_DIARIO_VALORDIARIO,
					PLANO.[PLANODIARIO_VALORKM] AS PLANO_DIARIO_VALORKM,
					PLANO.[PLANOLIVRE_VALORDIARIO] AS PLANO_LIVRE_VALORDIARIO,
					PLANO.[PLANOCONTROLADO_VALORDIARIO] AS PLANO_CONTROLADO_VALORDIARIO,
					PLANO.[PLANOCONTROLADO_VALORKM] AS PLANO_CONTROLADO_VALORKM,
					PLANO.[PLANOCONTROLADO_LIMITEKM] AS PLANO_CONTROLADO_LIMITEKM,

					GRUPO.[ID] AS GRUPO_ID,
					GRUPO.[NOME] AS GRUPO_NOME
				FROM 
					[TBPlanoDeCobranca] AS PLANO

					INNER JOIN

					[TBGrupo] AS GRUPO

					ON PLANO.[GRUPO_ID] = GRUPO.[ID]";

        public PlanoDeCobranca? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
			return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
		}
	}
}