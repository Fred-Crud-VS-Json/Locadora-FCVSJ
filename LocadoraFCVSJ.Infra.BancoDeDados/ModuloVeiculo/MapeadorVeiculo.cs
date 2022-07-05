using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo Registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", Registro.Id);
            comando.Parameters.AddWithValue("GRUPOVEICULO", Registro.GrupoVeiculo == null ? DBNull.Value : Registro.GrupoVeiculo.Id);
            comando.Parameters.AddWithValue("MODELO", Registro.Modelo);
            comando.Parameters.AddWithValue("MARCA", Registro.Marca);
            comando.Parameters.AddWithValue("PLACA", Registro.Placa);
            comando.Parameters.AddWithValue("COR", Registro.Cor);
            comando.Parameters.AddWithValue("TIPOCOMBUSTIVEL", Registro.TipoCombustivel);
            comando.Parameters.AddWithValue("CAPACIDADETANQUE", Registro.CapacidadeTanque);
            comando.Parameters.AddWithValue("ANO", Registro.Ano);
            comando.Parameters.AddWithValue("KMPERCORRIDO", Registro.KmPercorrido);
            comando.Parameters.AddWithValue("DETALHES", string.IsNullOrEmpty(Registro.Detalhes) ? DBNull.Value : Registro.Detalhes);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["VEICULO_ID"]);
            string modelo = Convert.ToString(leitorRegistro["VEICULO_MODELO"]);
            string marca = Convert.ToString(leitorRegistro["VEICULO_MARCA"]);
            string placa = Convert.ToString(leitorRegistro["VEICULO_PLACA"]);
            string cor = Convert.ToString(leitorRegistro["VEICULO_COR"]);
            TipoCalculoTaxa tipoCombustivel = (TipoCalculoTaxa)leitorRegistro["VEICULO_TIPOCOMBUSTIVEL"];
            int capacidadeTanque = Convert.ToInt32(leitorRegistro["VEICULO_CAPACIDADETANQUE"]);
            int ano = Convert.ToInt32(leitorRegistro["VEICULO_ANO"]);
            int kmPercorrido = Convert.ToInt32(leitorRegistro["VEICULO_KMPERCORRIDO"]);
            string detalhes = Convert.ToString(leitorRegistro["VEICULO_DETALHES"]);

            return new()
            {
                Id = id,
                GrupoVeiculo = new MapeadorGrupo().ConverterRegistro(leitorRegistro),
                Modelo = modelo,
                Marca = marca,
                Placa = placa,
                Cor = cor,
                TipoCombustivel = (TipoCombustivel)tipoCombustivel,
                CapacidadeTanque = capacidadeTanque,
                Ano = ano,
                KmPercorrido = kmPercorrido,
                Detalhes = detalhes,
            };         
        }
    }
}
