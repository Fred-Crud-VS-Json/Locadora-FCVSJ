

using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

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
                    [FOTO]
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
                    @FOTO
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
                    [FOTO] = @FOTO
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
                VEICULO.[FOTO] AS VEICULO_FOTO,

                GRUPO.[ID] AS GRUPO_ID,
                GRUPO.[NOME] AS GRUPO_NOME
            FROM
                [TBVEICULO] AS VEICULO INNER JOIN
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
                VEICULO.[FOTO] AS VEICULO_FOTO,

                GRUPO.[ID] AS GRUPO_ID,
                GRUPO.[NOME] AS GRUPO_NOME
            FROM
                [TBVEICULO] AS VEICULO INNER JOIN
                [TBGRUPO] AS GRUPO
            ON
                GRUPO.ID = VEICULO.GRUPOVEICULO";

        public string QuerySelecionarPorModelo =>
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
                VEICULO.[FOTO] AS VEICULO_FOTO,

                GRUPO.[ID] AS GRUPO_ID,
                GRUPO.[NOME] AS GRUPO_NOME
            FROM
                [TBVEICULO] AS VEICULO INNER JOIN
                [TBGRUPO] AS GRUPO
            ON
                GRUPO.ID = VEICULO.GRUPOVEICULO
            WHERE
                VEICULO.[MODELO] = @MODELO";

        public Veiculo? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            return SelecionarParametro(query, new SqlParameter(parametro, propriedade));
        }

        public void Salvar(Veiculo veiculo)
        {
            byte[] foto = GetFoto(veiculo.CaminhoFoto);

            var sql = "INSERT INTO TBVeiculo (GrupoVeiculo, Modelo, Marca, Placa, Cor, TipoCombustivel, CapacidadeTanque, Ano, KmPercorrido, Foto) VALUES (@GrupoVeiculo, @Modelo, @Marca, @Placa, @Cor, @TipoCombustivel, @CapacidadeTanque, @Ano, @KmPercorrido, @Foto)";

        }

        private byte[] GetFoto(string caminhoFoto)
        {
            byte[] foto;

            using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    foto = reader.ReadBytes((int)stream.Length);
                }
            }
            return foto;
        }
    }
}
