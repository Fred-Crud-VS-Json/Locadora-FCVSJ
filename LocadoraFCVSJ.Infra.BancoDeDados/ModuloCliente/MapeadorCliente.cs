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
            int id = Convert.ToInt32(leitorCliente["ID"]);
            string nome = Convert.ToString(leitorCliente["NOME"]);
            string cpf = Convert.ToString(leitorCliente["CPF"]);

            string cnpj = "";

            if (leitorCliente["CNPJ"] != DBNull.Value) 
                cnpj = Convert.ToString(leitorCliente["CNPJ"]);

            string cnh = Convert.ToString(leitorCliente["CNH"]);
            string telefone = Convert.ToString(leitorCliente["TELEFONE"]);
            string email = Convert.ToString(leitorCliente["EMAIL"]);
            string cidade = Convert.ToString(leitorCliente["CIDADE"]);
            string cep = Convert.ToString(leitorCliente["CEP"]);
            string numero = Convert.ToString(leitorCliente["NUMERO"]);
            string bairro = Convert.ToString(leitorCliente["BAIRRO"]);
            UF uf = (UF)leitorCliente["UF"];
            string complemento = Convert.ToString(leitorCliente["COMPLEMENTO"]);
            string rua = Convert.ToString(leitorCliente["RUA"]);

            return new Cliente()
            {
                Id = id,
                Nome = nome,
                CPF = cpf,
                CNPJ = cnpj,
                CNH = cnh,
                Telefone = telefone,
                Email = email,
                Cidade = cidade,
                CEP = cep,
                Numero = numero,
                Bairro = bairro,
                UF = uf,
                Complemento = complemento,
                Rua = rua
            };
        }
    }
}
