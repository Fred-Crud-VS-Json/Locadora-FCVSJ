using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo Registro, SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
