
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBaseSql<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario funcionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", funcionario.Id);
            comando.Parameters.AddWithValue("NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("USUARIO", funcionario.Usuario);
            comando.Parameters.AddWithValue("SENHA", funcionario.Senha);
            comando.Parameters.AddWithValue("SALARIO", funcionario.Salario);
            comando.Parameters.AddWithValue("DATAADMISSAO", funcionario.DataAdmissao);
            comando.Parameters.AddWithValue("NIVELACESSO", funcionario.NivelAcesso);
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorRegistro)
        {
            return new()
            {
                Id = Guid.Parse(leitorRegistro["FUNCIONARIO_ID"].ToString()),
                Nome = Convert.ToString(leitorRegistro["FUNCIONARIO_NOME"]),
                Usuario = Convert.ToString(leitorRegistro["FUNCIONARIO_USUARIO"]),
                Senha = Convert.ToString(leitorRegistro["FUNCIONARIO_SENHA"]),
                Salario = Convert.ToDecimal(leitorRegistro["FUNCIONARIO_SALARIO"]),
                DataAdmissao = Convert.ToDateTime(leitorRegistro["FUNCIONARIO_DATAADMISSAO"]),
                NivelAcesso = (NivelAcesso)leitorRegistro["FUNCIONARIO_NIVELACESSO"]
            };
        }
    }
}