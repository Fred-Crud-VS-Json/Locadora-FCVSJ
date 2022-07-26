using LocadoraFCVSJ.Dominio.Compartilhado.Enums;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa taxa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", taxa.Id);
            comando.Parameters.AddWithValue("NOME", taxa.Nome);
            comando.Parameters.AddWithValue("VALOR", taxa.Valor);
            comando.Parameters.AddWithValue("TIPOCALCULOTAXA", taxa.TipoCalculoTaxa);
        }

        public override Taxa ConverterRegistro(SqlDataReader leitorRegistro)
        {
            return new()
            {
                Id = Guid.Parse(leitorRegistro["TAXA_ID"].ToString()),
                Nome = Convert.ToString(leitorRegistro["TAXA_NOME"]),
                Valor = Convert.ToDecimal(leitorRegistro["TAXA_VALOR"]),
                TipoCalculoTaxa = (TipoCalculoTaxa)leitorRegistro["TAXA_TIPOCALCULO"]
            };
        }
    }
}