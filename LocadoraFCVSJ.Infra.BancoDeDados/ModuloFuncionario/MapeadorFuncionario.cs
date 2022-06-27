
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario funcionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", funcionario.Id);
            comando.Parameters.AddWithValue("NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("LOGIN", funcionario.Usuario);
            comando.Parameters.AddWithValue("SENHA", funcionario.Senha);
            comando.Parameters.AddWithValue("SALARIO", funcionario.Salario);
            comando.Parameters.AddWithValue("DATAADMISSAO", funcionario.DataAdmissao);
            comando.Parameters.AddWithValue("NIVELACESSO", funcionario.NivelAcesso);
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["ID"]);
            string nome = Convert.ToString(leitorRegistro["NOME"]);
            string login = Convert.ToString(leitorRegistro["LOGIN"]);
            string senha = Convert.ToString(leitorRegistro["SENHA"]);
            decimal salario = Convert.ToDecimal(leitorRegistro["SALARIO"]);
            DateTime dataAdmissao = Convert.ToDateTime(leitorRegistro["DATAADMISSAO"]);
            int nivelAcesso = Convert.ToInt32(leitorRegistro["NIVELACESSO"]);


            var funcionario = new Funcionario
            {
                Id = id,
                Nome = nome,
                Usuario = login,
                Senha = senha,
                Salario = salario,
                DataAdmissao = dataAdmissao,
                NivelAcesso = (NivelAcesso)nivelAcesso
            };

            return funcionario;
        }
    }
}