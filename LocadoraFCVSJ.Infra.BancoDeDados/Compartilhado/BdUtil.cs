using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado
{
    public static class BdUtil
    {
        private static readonly string StringConexao =
            @"Data Source=(LocalDB)\MSSqlLocalDB;
              Initial Catalog=DBLocadoraFCVSJ;
              Integrated Security=True;
              Pooling=False";

        private static SqlConnection? Conexao = null;

        public static void ExecutarSql(string query)
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(query, Conexao);

                Conexao.Open();

                comando.ExecuteNonQuery();
            }
        }
    }
}