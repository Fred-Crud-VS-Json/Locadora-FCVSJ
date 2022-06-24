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
            comando.Parameters.AddWithValue("CNPJ", cliente.CNPJ);
            comando.Parameters.AddWithValue("CNH", cliente.CNH);
            comando.Parameters.AddWithValue("TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("EMAIL", cliente.Email);
            comando.Parameters.AddWithValue("CIDADE", cliente.Cidade);
            comando.Parameters.AddWithValue("CEP", cliente.CEP);
            comando.Parameters.AddWithValue("NUMERO", cliente.Numero);
            comando.Parameters.AddWithValue("BAIRRO", cliente.Bairro);
            comando.Parameters.AddWithValue("ESTADO", cliente.UF);
            comando.Parameters.AddWithValue("COMPLEMENTO", cliente.Complemento);
            comando.Parameters.AddWithValue("RUA", cliente.Rua);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {
            int id = Convert.ToInt32(leitorCliente["ID"]);
            string nome = (string)leitorCliente["NOME"];
            string cpf = (string)leitorCliente["CPF"];
            string cnpj = (string)leitorCliente["CNPJ"];
            string cnh = (string)leitorCliente["CNH"];
            string telefone = (string)leitorCliente["TELEFONE"];
            string email = (string)leitorCliente["EMAIL"];
            string cidade = (string)leitorCliente["CIDADE"];
            string cep = (string)leitorCliente["CEP"];
            string numero = (string)leitorCliente["NUMERO"];
            string bairro = (string)leitorCliente["BAIRRO"];
            string estado = (string)leitorCliente["ESTADO"];
            string complemento = (string)leitorCliente["COMPLEMENTO"];
            string rua = (string)leitorCliente["RUA"];

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
                UF = estado,
                Complemento = complemento,
                Rua = rua
            };
        }
    }
}
