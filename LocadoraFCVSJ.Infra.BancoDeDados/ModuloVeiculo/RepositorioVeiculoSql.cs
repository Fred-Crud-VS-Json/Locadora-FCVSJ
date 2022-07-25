

using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo
{
    public class RepositorioVeiculoSql : RepositorioBase<Veiculo, MapeadorVeiculo>, IRepositorioVeiculo
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBVEICULO]
                (
                    [ID],
                    [MODELO],
                    [MARCA],
                    [PLACA],
                    [COR],
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADETANQUE],
                    [ANO],
                    [KMPERCORRIDO],
                    [FOTO],
                    [GRUPO_ID]
                )
                VALUES
                (
                    @ID,
                    @MODELO,
                    @MARCA,
                    @PLACA,
                    @COR,
                    @TIPOCOMBUSTIVEL,
                    @CAPACIDADETANQUE,
                    @ANO,
                    @KMPERCORRIDO,
                    @FOTO,
                    @GRUPO_ID
                )";

        protected override string QueryEditar =>
            @"UPDATE [TBVEICULO]
                SET
                    [MODELO] = @MODELO,
                    [MARCA] = @MARCA,
                    [PLACA] = @PLACA,
                    [COR] = @COR,
                    [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                    [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                    [ANO] = @ANO,
                    [KMPERCORRIDO] = @KMPERCORRIDO,
                    [FOTO] = @FOTO,
                    [GRUPO_ID] = @GRUPO_ID
                WHERE
                    [ID] = @ID";

        protected override string QueryExcluir => 
            @"DELETE FROM [TBVEICULO]
                WHERE
                    [ID] = @ID";

        protected override string QuerySelecionarPorId =>
            @"SELECT
                VEICULO.[ID] AS VEICULO_ID,
                VEICULO.[MODELO] AS VEICULO_MODELO,
                VEICULO.[MARCA] AS VEICULO_MARCA,
                VEICULO.[PLACA] AS VEICULO_PLACA,
                VEICULO.[COR] AS VEICULO_COR,
                VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,
                VEICULO.[CAPACIDADETANQUE] AS VEICULO_CAPACIDADETANQUE,
                VEICULO.[ANO] AS VEICULO_ANO,
                VEICULO.[KMPERCORRIDO] AS VEICULO_KMPERCORRIDO,
                VEICULO.[FOTO] AS VEICULO_FOTO,

                GRUPO.[ID] AS GRUPO_ID,
                GRUPO.[NOME] AS GRUPO_NOME
            FROM
                [TBVEICULO] AS VEICULO INNER JOIN
                [TBGRUPO] AS GRUPO
            ON
                VEICULO.[GRUPO_ID] = GRUPO.[ID]
            WHERE
                VEICULO.[ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT
                VEICULO.[ID] AS VEICULO_ID,
                VEICULO.[MODELO] AS VEICULO_MODELO,
                VEICULO.[MARCA] AS VEICULO_MARCA,
                VEICULO.[PLACA] AS VEICULO_PLACA,
                VEICULO.[COR] AS VEICULO_COR,
                VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,
                VEICULO.[CAPACIDADETANQUE] AS VEICULO_CAPACIDADETANQUE,
                VEICULO.[ANO] AS VEICULO_ANO,
                VEICULO.[KMPERCORRIDO] AS VEICULO_KMPERCORRIDO,
                VEICULO.[FOTO] AS VEICULO_FOTO,

                GRUPO.[ID] AS GRUPO_ID,
                GRUPO.[NOME] AS GRUPO_NOME
            FROM
                [TBVEICULO] AS VEICULO INNER JOIN
                [TBGRUPO] AS GRUPO
            ON
                VEICULO.[GRUPO_ID] = GRUPO.[ID]";

        public Veiculo? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }
        
    }
}