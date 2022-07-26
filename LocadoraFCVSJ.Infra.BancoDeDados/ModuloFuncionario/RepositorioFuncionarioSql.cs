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
                    [LOGIN],
                    [SENHA],
                    [SALARIO],
                    [DATAADMISSAO],
                    [NIVELACESSO]
                )
                VALUES
                (
                    @ID,
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @SALARIO,
                    @DATAADMISSAO,
                    @NIVELACESSO
                )";

        protected override string QueryEditar =>
            @"UPDATE [TBFUNCIONARIO]
                SET
                    [NOME] = @NOME,
                    [LOGIN] = @LOGIN,
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
                FUNCIONARIO.[LOGIN] AS FUNCIONARIO_LOGIN,
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
                FUNCIONARIO.[LOGIN] AS FUNCIONARIO_LOGIN,
                FUNCIONARIO.[SENHA] AS FUNCIONARIO_SENHA,
                FUNCIONARIO.[SALARIO] AS FUNCIONARIO_SALARIO,
                FUNCIONARIO.[DATAADMISSAO] AS FUNCIONARIO_DATAADMISSAO,
                FUNCIONARIO.[NIVELACESSO] AS FUNCIONARIO_NIVELACESSO
            FROM
                [TBFUNCIONARIO] AS FUNCIONARIO";

        private string QuerySelecionarPorLogin =>
            @"SELECT 
                    FUNCIONARIO.[ID] AS FUNCIONARIO_ID,
                    FUNCIONARIO.[NOME] AS FUNCIONARIO_NOME,
                    FUNCIONARIO.[LOGIN] AS FUNCIONARIO_LOGIN,
                    FUNCIONARIO.[SENHA] AS FUNCIONARIO_SENHA,
                    FUNCIONARIO.[SALARIO] AS FUNCIONARIO_SALARIO,
                    FUNCIONARIO.[DATAADMISSAO] AS FUNCIONARIO_DATAADMISSAO,
                    FUNCIONARIO.[NIVELACESSO] AS FUNCIONARIO_NIVELACESSO
                FROM
                    [TBFUNCIONARIO] AS FUNCIONARIO
                WHERE 
	                FUNCIONARIO.[LOGIN] = @LOGIN";

        public Funcionario? SelecionarPorLogin(string login)
        {
            return SelecionarParametro(QuerySelecionarPorLogin, new SqlParameter("LOGIN", login));
        }
    }
}