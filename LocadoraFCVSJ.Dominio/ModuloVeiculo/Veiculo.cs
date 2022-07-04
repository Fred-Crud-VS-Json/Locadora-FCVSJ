using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraFCVSJ.Dominio.ModuloVeiculo
{
    public class Veiculo :EntidadeBase<Veiculo>
    {
        public Veiculo()
        {
        }

        public Veiculo(Grupo grupoVeiculo, string modelo, string marca, string placa, string cor, TipoCombustivel? tipoCombustivel, decimal capacidadeTanque, int ano, decimal kmPercorrido, string detalhes)
        {
            GrupoVeiculo = grupoVeiculo;
            Modelo = modelo;
            Marca = marca;
            Placa = placa;
            Cor = cor;
            TipoCombustivel = tipoCombustivel;
            CapacidadeTanque = capacidadeTanque;
            Ano = ano;
            KmPercorrido = kmPercorrido;
            Detalhes = detalhes;
        }

        public Grupo GrupoVeiculo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public TipoCombustivel? TipoCombustivel { get; set; }
        public decimal CapacidadeTanque { get; set; }
        public int Ano { get; set; }
        public decimal KmPercorrido { get; set; }
        public string Detalhes { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   EqualityComparer<Grupo>.Default.Equals(GrupoVeiculo, veiculo.GrupoVeiculo) &&
                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   Placa == veiculo.Placa &&
                   Cor == veiculo.Cor &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   Ano == veiculo.Ano &&
                   KmPercorrido == veiculo.KmPercorrido &&
                   Detalhes == veiculo.Detalhes;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(GrupoVeiculo);
            hash.Add(Modelo);
            hash.Add(Marca);
            hash.Add(Placa);
            hash.Add(Cor);
            hash.Add(TipoCombustivel);
            hash.Add(CapacidadeTanque);
            hash.Add(Ano);
            hash.Add(KmPercorrido);
            hash.Add(Detalhes);
            return hash.ToHashCode();
        }
    }
}
