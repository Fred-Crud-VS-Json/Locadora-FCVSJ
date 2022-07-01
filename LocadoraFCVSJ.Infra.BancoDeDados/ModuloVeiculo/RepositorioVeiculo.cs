

using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo
{
    public class RepositorioVeiculo : RepositorioBase<Veiculo, MapeadorVeiculo>, IRepositorioVeiculo
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBVEICULO]
                (
                    [GRUPOVEICULO],
                    [MODELO],
                    [MARCA],
                    [PLACA],
                    [COR],
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADETANQUE],
                    [ANO],
                    [KMPERCORRIDO],
                    [DETALHES]
                )
                VALUES
                (
                    @GRUPOVEICULO,
                    @MODELO,
                    @MARCA,
                    @PLACA,
                    @COR,
                    @TIPOCOMBUSTIVEL,
                    @CAPACIDADETANQUE,
                    @ANO,
                    @KMPERCORRIDO,
                    @DETALHES
                );SELECT SCOPE_IDENTITY();";

        protected override string QueryEditar =>
            @"UPDATE [TBVEICULO]
                SET
                    [GRUPOVEICULO] = @GRUPOVEICULO,
                    [MODELO] = @MODELO,
                    [MARCA] = @MARCA,
                    [PLACA] = @PLACA,
                    [COR] = @COR,
                    [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                    [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                    [ANO] = @ANO,
                    [KMPERCORRIDO] = @KMPERCORRIDO,
                    [DETALHES] = @DETALHES
                WHERE
                    [ID] = @ID";

        protected override string QueryExcluir => 
            @"DELETE FROM [TBVEICULO]
                WHERE
                    [ID] = @ID";

        protected override string QuerySelecionarPorId =>
            @"SELECT
                VEICULO.[ID] AS VEICULO_ID,
                VEICULO.[GRUPOVEICULO] AS VEICULO_GRUPOVEICULO,
                VEICULO.[MODELO] AS VEICULO_MODELO,
                VEICULO.[MARCA] AS VEICULO_MARCA,
                VEICULO.[PLACA] AS VEICULO_PLACA,
                VEICULO.[COR] AS VEICULO_COR,
                VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,
                VEICULO.[CAPACIDADETANQUE] AS VEICULO_CAPACIDADETANQUE,
                VEICULO.[ANO] AS VEICULO_ANO,
                VEICULO.[KMPERCORRIDO] AS VEICULO_KMPERCORRIDO,
                VEICULO.[DETALHES] AS VEICULO_DETALHES,
                GRUPO.[NOME] AS GRUPO_NOME
            FROM
                [TBVEICULO] AS VEICULO LEFT JOIN
                [TBGRUPO] AS GRUPO
            ON
                GRUPO.ID = VEICULO.GRUPOVEICULO
            WHERE
                VEICULO.[ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT
                VEICULO.[ID] AS VEICULO_ID,
                VEICULO.[GRUPOVEICULO] AS VEICULO_GRUPOVEICULO,
                VEICULO.[MODELO] AS VEICULO_MODELO,
                VEICULO.[MARCA] AS VEICULO_MARCA,
                VEICULO.[PLACA] AS VEICULO_PLACA,
                VEICULO.[COR] AS VEICULO_COR,
                VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,
                VEICULO.[CAPACIDADETANQUE] AS VEICULO_CAPACIDADETANQUE,
                VEICULO.[ANO] AS VEICULO_ANO,
                VEICULO.[KMPERCORRIDO] AS VEICULO_KMPERCORRIDO,
                VEICULO.[DETALHES] AS VEICULO_DETALHES,
                GRUPO.[NOME] AS GRUPO_NOME
            FROM
                [TBVEICULO] AS VEICULO LEFT JOIN
                [TBGRUPO] AS GRUPO
            ON
                GRUPO.ID = VEICULO.GRUPOVEICULO";

        public Veiculo? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            throw new NotImplementedException();
        }
    }
}
