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
            if (condutor.Cliente != null)
            {
                comando.Parameters.AddWithValue("CLIENTE_ID", condutor.Cliente.Id);
            }
            
            
         
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorCondutor)
        {
            int id = Convert.ToInt32(leitorCondutor["CONDUTOR_ID"]);
            string nome = Convert.ToString(leitorCondutor["CONDUTOR_NOME"]);
            string cpf = Convert.ToString(leitorCondutor["CONDUTOR_CPF"]);

            string cnpj = "";

            if (leitorCondutor["CONDUTOR_CNPJ"] != DBNull.Value)
            cnpj = Convert.ToString(leitorCondutor["CONDUTOR_CNPJ"]);

            string cnh = Convert.ToString(leitorCondutor["CONDUTOR_CNH"]);
            DateTime dataVencimento = Convert.ToDateTime(leitorCondutor["CONDUTOR_DATAVENCIMENTO"]);
            string telefone = Convert.ToString(leitorCondutor["CONDUTOR_TELEFONE"]);
            string email = Convert.ToString(leitorCondutor["CONDUTOR_EMAIL"]);
            string cidade = Convert.ToString(leitorCondutor["CONDUTOR_CIDADE"]);
            string cep = Convert.ToString(leitorCondutor["CONDUTOR_CEP"]);
            string numero = Convert.ToString(leitorCondutor["CONDUTOR_NUMERO"]);
            string bairro = Convert.ToString(leitorCondutor["CONDUTOR_BAIRRO"]);
            UF uf = (UF)leitorCondutor["CONDUTOR_UF"];
            string complemento = Convert.ToString(leitorCondutor["CONDUTOR_COMPLEMENTO"]);
            string rua = Convert.ToString(leitorCondutor["CONDUTOR_RUA"]);

            int? idCliente = 0;

            if (leitorCondutor["CONDUTOR_CLIENTE_ID"] != DBNull.Value)
                idCliente = Convert.ToInt32(leitorCondutor["CONDUTOR_CLIENTE_ID"]);

            string nomeCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_NOME"]);
            string cpfCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_CPF"]);

            string cnpjCliente = "";

            if (leitorCondutor["CONDUTOR_CLIENTE_CNPJ"] != DBNull.Value)
                cnpjCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_CNPJ"]);

            string cnhCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_CNH"]);
            //DateTime dataVencimentoCliente = Convert.ToDateTime(leitorCondutor["CONDUTOR_DATAVENCIMENTO"]);
            string telefoneCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_TELEFONE"]);
            string emailCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_EMAIL"]);
            string cidadeCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_CIDADE"]);
            string cepCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_CEP"]);
            string numeroCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_NUMERO"]);
            string bairroCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_BAIRRO"]);
            UF ufCliente = (UF)leitorCondutor["CONDUTOR_CLIENTE_UF"];
            string complementoCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_COMPLEMENTO"]);
            string ruaCliente = Convert.ToString(leitorCondutor["CONDUTOR_CLIENTE_RUA"]);

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
                Rua = rua,
                
                Cliente = new()
                {
                    Id = (int)idCliente,
                    Nome = nomeCliente,
                    CPF = cpfCliente,
                    CNPJ = cnpjCliente,
                    CNH = cnhCliente,
                    Telefone = telefoneCliente,
                    Email = emailCliente,
                    Cidade = cidadeCliente,
                    CEP = cepCliente,
                    Numero = numeroCliente,
                    Bairro = bairroCliente,
                    UF = ufCliente,
                    Complemento = complementoCliente,
                    Rua = ruaCliente
                }
            };
        }
    }
}
