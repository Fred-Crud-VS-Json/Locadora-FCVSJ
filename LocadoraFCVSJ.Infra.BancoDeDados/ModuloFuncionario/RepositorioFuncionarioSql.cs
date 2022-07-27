using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario
{
    public class RepositorioFuncionarioSql : RepositorioBaseSql<Funcionario, MapeadorFuncionario>, IRepositorioFuncionario
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                (
                    [ID],
                    [NOME],
                    [USUARIO],
                    [SENHA],
                    [SALARIO],
                    [DATAADMISSAO],
                    [NIVELACESSO]
                )
                VALUES
                (
                    @ID,
                    @NOME,
                    @USUARIO,
                    @SENHA,
                    @SALARIO,
                    @DATAADMISSAO,
                    @NIVELACESSO
                )";

        protected override string QueryEditar =>
            @"UPDATE [TBFUNCIONARIO]
                SET
                    [NOME] = @NOME,
                    [USUARIO] = @USUARIO,
                    [SENHA] = @SENHA,
                    [SALARIO] = @SALARIO,
                    [DATAADMISSAO] = @DATAADMISSAO,
                    [NIVELACESSO] = @NIVELACESSO
                WHERE
                    [ID] = @ID";

        protected override string QueryExcluir =>
            @"DELETE FROM [TBFUNCIONARIO]
                WHERE
                    [ID] = @ID";

        protected override string QuerySelecionarPorId =>
            @"SELECT
                FUNCIONARIO.[ID] AS FUNCIONARIO_ID,
                FUNCIONARIO.[NOME] AS FUNCIONARIO_NOME,
                FUNCIONARIO.[USUARIO] AS FUNCIONARIO_USUARIO,
                FUNCIONARIO.[SENHA] AS FUNCIONARIO_SENHA,
                FUNCIONARIO.[SALARIO] AS FUNCIONARIO_SALARIO,
                FUNCIONARIO.[DATAADMISSAO] AS FUNCIONARIO_DATAADMISSAO,
                FUNCIONARIO.[NIVELACESSO] AS FUNCIONARIO_NIVELACESSO
            FROM
                [TBFUNCIONARIO] AS FUNCIONARIO
            WHERE
                FUNCIONARIO.[ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT
                FUNCIONARIO.[ID] AS FUNCIONARIO_ID,
                FUNCIONARIO.[NOME] AS FUNCIONARIO_NOME,
                FUNCIONARIO.[USUARIO] AS FUNCIONARIO_USUARIO,
                FUNCIONARIO.[SENHA] AS FUNCIONARIO_SENHA,
                FUNCIONARIO.[SALARIO] AS FUNCIONARIO_SALARIO,
                FUNCIONARIO.[DATAADMISSAO] AS FUNCIONARIO_DATAADMISSAO,
                FUNCIONARIO.[NIVELACESSO] AS FUNCIONARIO_NIVELACESSO
            FROM
                [TBFUNCIONARIO] AS FUNCIONARIO";

        private string QuerySelecionarPorUsuario =>
            @"SELECT 
                    FUNCIONARIO.[ID] AS FUNCIONARIO_ID,
                    FUNCIONARIO.[NOME] AS FUNCIONARIO_NOME,
                    FUNCIONARIO.[USUARIO] AS FUNCIONARIO_USUARIO,
                    FUNCIONARIO.[SENHA] AS FUNCIONARIO_SENHA,
                    FUNCIONARIO.[SALARIO] AS FUNCIONARIO_SALARIO,
                    FUNCIONARIO.[DATAADMISSAO] AS FUNCIONARIO_DATAADMISSAO,
                    FUNCIONARIO.[NIVELACESSO] AS FUNCIONARIO_NIVELACESSO
                FROM
                    [TBFUNCIONARIO] AS FUNCIONARIO
                WHERE 
	                FUNCIONARIO.[USUARIO] = @USUARIO";

        public Funcionario? SelecionarPorUsuario(string usuario)
        {
            return SelecionarParametro(QuerySelecionarPorUsuario, new SqlParameter("USUARIO", usuario));
        }
    }
}