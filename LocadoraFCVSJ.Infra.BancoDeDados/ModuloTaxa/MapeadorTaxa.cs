using LocadoraFCVSJ.Dominio.Compartilhado;
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
            int id = Convert.ToInt32(leitorRegistro["ID"]);
            string? nome = Convert.ToString(leitorRegistro["NOME"]);
            decimal valor = Convert.ToDecimal(leitorRegistro["VALOR"]);
            TipoCalculoTaxa tipoCalculoTaxa = (TipoCalculoTaxa)leitorRegistro["TIPOCALCULOTAXA"];

            return new Taxa
            {
                Id = id,
                Nome = nome,
                Valor = valor,
                TipoCalculoTaxa = tipoCalculoTaxa
            };
        }
    }
}