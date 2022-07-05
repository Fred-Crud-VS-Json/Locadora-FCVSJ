using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo
{
    public class MapeadorGrupo : MapeadorBase<Grupo>
    {
        public override void ConfigurarParametros(Grupo grupo, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", grupo.Id);
            comando.Parameters.AddWithValue("NOME", grupo.Nome);
        }

        public override Grupo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["GRUPO_ID"]);
            string? nome = Convert.ToString(leitorRegistro["GRUPO_NOME"]);

            return new Grupo
            {
                Id = id,
                Nome = nome
            };
        }
    }
}