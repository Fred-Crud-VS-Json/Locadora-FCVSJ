using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor condutor, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", condutor.Id);
            comando.Parameters.AddWithValue("NOME", condutor.Nome);
            comando.Parameters.AddWithValue("CPF", condutor.CPF);
            comando.Parameters.AddWithValue("CNPJ", string.IsNullOrEmpty(condutor.CNPJ) ? DBNull.Value : condutor.CNPJ);
            comando.Parameters.AddWithValue("CNH", condutor.CNH);
            comando.Parameters.AddWithValue("DATAVENCIMENTO", condutor.DataVencimento);
            comando.Parameters.AddWithValue("TELEFONE", condutor.Telefone);
            comando.Parameters.AddWithValue("EMAIL", condutor.Email);
            comando.Parameters.AddWithValue("CIDADE", condutor.Cidade);
            comando.Parameters.AddWithValue("CEP", condutor.CEP);
            comando.Parameters.AddWithValue("NUMERO", condutor.Numero);
            comando.Parameters.AddWithValue("BAIRRO", condutor.Bairro);
            comando.Parameters.AddWithValue("UF", condutor.UF);
            comando.Parameters.AddWithValue("COMPLEMENTO", condutor.Complemento);
            comando.Parameters.AddWithValue("RUA", condutor.Rua);
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorCondutor)
        {
            int id = Convert.ToInt32(leitorCondutor["ID"]);
            string nome = Convert.ToString(leitorCondutor["NOME"]);
            string cpf = Convert.ToString(leitorCondutor["CPF"]);

            string cnpj = "";

            if (leitorCondutor["CNPJ"] != DBNull.Value)
                cnpj = Convert.ToString(leitorCondutor["CNPJ"]);

            string cnh = Convert.ToString(leitorCondutor["CNH"]);
            DateTime dataVencimento = Convert.ToDateTime(leitorCondutor["DATAVENCIMENTO"]);
            string telefone = Convert.ToString(leitorCondutor["TELEFONE"]);
            string email = Convert.ToString(leitorCondutor["EMAIL"]);
            string cidade = Convert.ToString(leitorCondutor["CIDADE"]);
            string cep = Convert.ToString(leitorCondutor["CEP"]);
            string numero = Convert.ToString(leitorCondutor["NUMERO"]);
            string bairro = Convert.ToString(leitorCondutor["BAIRRO"]);
            UF uf = (UF)leitorCondutor["UF"];
            string complemento = Convert.ToString(leitorCondutor["COMPLEMENTO"]);
            string rua = Convert.ToString(leitorCondutor["RUA"]);

            return new Condutor()
            {
                Id = id,
                Nome = nome,
                CPF = cpf,
                CNPJ = cnpj,
                CNH = cnh,
                DataVencimento = dataVencimento,
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
