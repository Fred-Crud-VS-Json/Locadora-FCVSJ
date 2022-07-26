using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBaseSql<Condutor>
    {
        public override void ConfigurarParametros(Condutor condutor, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", condutor.Id);
            comando.Parameters.AddWithValue("NOME", condutor.Nome);
            comando.Parameters.AddWithValue("CPF", condutor.CPF);
            comando.Parameters.AddWithValue("CNPJ", string.IsNullOrEmpty(condutor.CNPJ) ? DBNull.Value : condutor.CNPJ);
            comando.Parameters.AddWithValue("CNH", condutor.CNH);
            comando.Parameters.AddWithValue("DATAVENCIMENTO", condutor.ValidadeCnh);
            comando.Parameters.AddWithValue("TELEFONE", condutor.Telefone);
            comando.Parameters.AddWithValue("EMAIL", condutor.Email);
            comando.Parameters.AddWithValue("CIDADE", condutor.Cidade);
            comando.Parameters.AddWithValue("CEP", condutor.CEP);
            comando.Parameters.AddWithValue("NUMERO", condutor.Numero);
            comando.Parameters.AddWithValue("BAIRRO", condutor.Bairro);
            comando.Parameters.AddWithValue("UF", condutor.UF);
            comando.Parameters.AddWithValue("COMPLEMENTO", condutor.Complemento);
            comando.Parameters.AddWithValue("RUA", condutor.Rua);
            comando.Parameters.AddWithValue("CLIENTE_ID", condutor.Cliente.Id);
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorCondutor)
        {
            string cnpj = "";

            if (leitorCondutor["CONDUTOR_CNPJ"] != DBNull.Value)
            cnpj = Convert.ToString(leitorCondutor["CONDUTOR_CNPJ"]);

            return new()
            {
                Id = Guid.Parse(leitorCondutor["CONDUTOR_ID"].ToString()),
                Nome = Convert.ToString(leitorCondutor["CONDUTOR_NOME"]),
                CPF = Convert.ToString(leitorCondutor["CONDUTOR_CPF"]),
                CNPJ = cnpj,
                CNH = Convert.ToString(leitorCondutor["CONDUTOR_CNH"]),
                ValidadeCnh = Convert.ToDateTime(leitorCondutor["CONDUTOR_DATAVENCIMENTO"]),
                Telefone = Convert.ToString(leitorCondutor["CONDUTOR_TELEFONE"]),
                Email = Convert.ToString(leitorCondutor["CONDUTOR_EMAIL"]),
                Cidade = Convert.ToString(leitorCondutor["CONDUTOR_CIDADE"]),
                CEP = Convert.ToString(leitorCondutor["CONDUTOR_CEP"]),
                Numero = Convert.ToString(leitorCondutor["CONDUTOR_NUMERO"]),
                Bairro = Convert.ToString(leitorCondutor["CONDUTOR_BAIRRO"]),
                UF = (UF)leitorCondutor["CONDUTOR_UF"],
                Complemento = Convert.ToString(leitorCondutor["CONDUTOR_COMPLEMENTO"]),
                Rua = Convert.ToString(leitorCondutor["CONDUTOR_RUA"]),
                Cliente = new MapeadorCliente().ConverterRegistro(leitorCondutor)
            };
        }
    }
}