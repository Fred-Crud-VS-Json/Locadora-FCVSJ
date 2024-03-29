﻿using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBaseSql<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo Registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", Registro.Id);
            comando.Parameters.AddWithValue("MODELO", Registro.Modelo);
            comando.Parameters.AddWithValue("MARCA", Registro.Marca);
            comando.Parameters.AddWithValue("PLACA", Registro.Placa);
            comando.Parameters.AddWithValue("COR", Registro.Cor);
            comando.Parameters.AddWithValue("TIPOCOMBUSTIVEL", Registro.TipoCombustivel);
            comando.Parameters.AddWithValue("CAPACIDADETANQUE", Registro.CapacidadeTanque);
            comando.Parameters.AddWithValue("ANO", Registro.Ano);
            comando.Parameters.AddWithValue("KMPERCORRIDO", Registro.KmPercorrido);
            comando.Parameters.AddWithValue("FOTO", Registro.Foto);
            comando.Parameters.AddWithValue("GRUPO_ID", Registro.Grupo.Id);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            return new()
            {
                Id = Guid.Parse(leitorRegistro["VEICULO_ID"].ToString()),
                Modelo = Convert.ToString(leitorRegistro["VEICULO_MODELO"]),
                Marca = Convert.ToString(leitorRegistro["VEICULO_MARCA"]),
                Placa = Convert.ToString(leitorRegistro["VEICULO_PLACA"]),
                Cor = Convert.ToString(leitorRegistro["VEICULO_COR"]),
                TipoCombustivel = (TipoCombustivel)leitorRegistro["VEICULO_TIPOCOMBUSTIVEL"],
                CapacidadeTanque = Convert.ToInt32(leitorRegistro["VEICULO_CAPACIDADETANQUE"]),
                Ano = Convert.ToInt32(leitorRegistro["VEICULO_ANO"]),
                KmPercorrido = Convert.ToInt32(leitorRegistro["VEICULO_KMPERCORRIDO"]),
                Foto = (byte[])leitorRegistro["VEICULO_FOTO"],
                Grupo = new MapeadorGrupo().ConverterRegistro(leitorRegistro),
            };         
        }
    }
}