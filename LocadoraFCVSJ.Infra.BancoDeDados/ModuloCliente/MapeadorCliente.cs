using LocadoraFCVSJ.Compartilhado;
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
            comando.Parameters.AddWithValue("CPF", cliente.CPF);
            comando.Parameters.AddWithValue("CNPJ", string.IsNullOrEmpty(cliente.CNPJ) ? DBNull.Value : cliente.CNPJ);
            comando.Parameters.AddWithValue("CNH", cliente.CNH);
            comando.Parameters.AddWithValue("TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("EMAIL", cliente.Email);
            comando.Parameters.AddWithValue("CIDADE", cliente.Cidade);
            comando.Parameters.AddWithValue("CEP", cliente.CEP);
            comando.Parameters.AddWithValue("NUMERO", cliente.Numero);
            comando.Parameters.AddWithValue("BAIRRO", cliente.Bairro);
            comando.Parameters.AddWithValue("UF", cliente.UF);
            comando.Parameters.AddWithValue("COMPLEMENTO", cliente.Complemento);
            comando.Parameters.AddWithValue("RUA", cliente.Rua);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {
            string cnpj = "";

            if (leitorCliente["CLIENTE_CNPJ"] != DBNull.Value) 
                cnpj = Convert.ToString(leitorCliente["CLIENTE_CNPJ"]);

            return new()
            {
                Id = Guid.Parse(leitorCliente["CLIENTE_ID"].ToString()),
                Nome = Convert.ToString(leitorCliente["CLIENTE_NOME"]),
                CPF = Convert.ToString(leitorCliente["CLIENTE_CPF"]),
                CNPJ = cnpj,
                CNH = Convert.ToString(leitorCliente["CLIENTE_CNH"]),
                Telefone = Convert.ToString(leitorCliente["CLIENTE_TELEFONE"]),
                Email = Convert.ToString(leitorCliente["CLIENTE_EMAIL"]),
                Cidade = Convert.ToString(leitorCliente["CLIENTE_CIDADE"]),
                CEP = Convert.ToString(leitorCliente["CLIENTE_CEP"]),
                Numero = Convert.ToString(leitorCliente["CLIENTE_NUMERO"]),
                Bairro = Convert.ToString(leitorCliente["CLIENTE_BAIRRO"]),
                UF = (UF)leitorCliente["CLIENTE_UF"],
                Complemento = Convert.ToString(leitorCliente["CLIENTE_COMPLEMENTO"]),
                Rua = Convert.ToString(leitorCliente["CLIENTE_RUA"])
            };
        }
    }
}