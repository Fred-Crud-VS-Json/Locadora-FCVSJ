using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string QueryInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                (
                    [NOME],
                    [LOGIN],
                    [SENHA],
                    [SALARIO],
                    [DATAADMISSAO],
                    [NIVELACESSO]
                )
                VALUES
                (
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @SALARIO,
                    @DATAADMISSAO,
                    @NIVELACESSO
                );SELECT SCOPE_IDENTITY();";

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
                [ID],
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATAADMISSAO],
                [NIVELACESSO]
            FROM
                [TBFUNCIONARIO]
            WHERE
                [ID] = @ID";

        protected override string QuerySelecionarTodos =>
            @"SELECT
                [ID],
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATAADMISSAO],
                [NIVELACESSO]
            FROM
                [TBFUNCIONARIO]";
    }
}
