using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", cliente.Id);
            comando.Parameters.AddWithValue("NOME", cliente.Nome);
            comando.Parameters.AddWithValue("DADO", cliente.Dado);
            comando.Parameters.AddWithValue("ENDERECO", cliente.Endereco);
            comando.Parameters.AddWithValue("TIPO", cliente.Tipo);
            comando.Parameters.AddWithValue("CNH", cliente.CNH);
            comando.Parameters.AddWithValue("TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("EMAIL", cliente.Email);

        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {
            int id = Convert.ToInt32(leitorCliente["ID"]);
            string nome = (string)leitorCliente["NOME"];
            string dados = (string)leitorCliente["DADO"];
            string endereco = (string)leitorCliente["ENDERECO"];
            string tipo = (string)leitorCliente["TIPO"];
            string cnh = (string)leitorCliente["CNH"];
            string telefone = (string)leitorCliente["TELEFONE"];
            string email = (string)leitorCliente["EMAIL"];

            return new Cliente()
            {
                Id = id,
                Nome = nome,
                Dado = dados,
                Endereco = endereco,
                Tipo = tipo,
                CNH = cnh,
                Telefone = telefone,
                Email = email
            };
        }
    }
}
